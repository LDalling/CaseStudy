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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Result()
        {

            ViewData["Message"] = "Your application description page.";

            return View();
        }
    }
}
