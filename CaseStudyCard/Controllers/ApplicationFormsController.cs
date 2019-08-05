using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CaseStudyCard.Models;

namespace CaseStudyCard.Controllers
{
    public class ApplicationFormsController : Controller
    {
        private readonly CaseStudyCardContext _context;

        public ApplicationFormsController(CaseStudyCardContext context)
        {
            _context = context;
        }

        // GET: ApplicationForms
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApplicationForm.ToListAsync());
        }

        // GET: ApplicationForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationForm = await _context.ApplicationForm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationForm == null)
            {
                return NotFound();
            }

            return View(applicationForm);
        }

        // GET: ApplicationForms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApplicationForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DOB,Income,CardsShown")] ApplicationForm applicationForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicationForm);
        }

        // GET: ApplicationForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationForm = await _context.ApplicationForm.FindAsync(id);
            if (applicationForm == null)
            {
                return NotFound();
            }
            return View(applicationForm);
        }

        // POST: ApplicationForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,DOB,Income,CardsShown")] ApplicationForm applicationForm)
        {
            if (id != applicationForm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationFormExists(applicationForm.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(applicationForm);
        }

        // GET: ApplicationForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationForm = await _context.ApplicationForm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationForm == null)
            {
                return NotFound();
            }

            return View(applicationForm);
        }

        // POST: ApplicationForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicationForm = await _context.ApplicationForm.FindAsync(id);
            _context.ApplicationForm.Remove(applicationForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationFormExists(int id)
        {
            return _context.ApplicationForm.Any(e => e.Id == id);
        }
    }
}
