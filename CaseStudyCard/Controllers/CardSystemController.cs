using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CaseStudyCard.Models;
using System.Collections.Specialized;

namespace CaseStudyCard.Controllers
{
    
    public class CardSystemController : Controller
    {
        //We need the database context to insert the applicationforms.
        //Not sure this is the ideal way, but 
        private readonly CaseStudyCardContext _context;
        public CardSystemController(CaseStudyCardContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> FormResponse(ApplicationForm form)
        {
            //add new form to database
            ApplicationResult result = new ApplicationResult(form);
            result.Cards = GetSuitableCards(form);
            foreach (ClientCreditCard c in result.Cards)
                { form.CardsShown += c.ID+","; }
            _context.Add(form);
            await _context.SaveChangesAsync();
            return View(result);
        }
        private List<ClientCreditCard> GetSuitableCards(ApplicationForm form)
        {
            int Age = (int)Math.Floor(DateTime.Now.Subtract(form.DOB).TotalDays / 365);
            var Cards2 = _context.CreditCard.Where(c => c.MinimumAge < Age).ToList();

            var Cards = _context.CreditCard.Where(c => c.MinimumAge < Age &&
                c.MaximumEarnings > (int) form.Income &&
                c.MinimumEarnings <= (int) form.Income)
                .Select(c => new ClientCreditCard(c))
                .ToList();
            return Cards;
        }
    }
}
