using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Evite.Data;

namespace Evite.Controllers
{
    public class HomeController : Controller
    {        
        private readonly EviteDBContext _context;

        public HomeController(EviteDBContext context)
        {
            _context = context;    
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "First Running APP";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact Page";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RsvpForm() {
            return View();
        }
        [HttpPost]
        public IActionResult RsvpForm(ResponseToEvite responseToEvite) {

            if (ModelState.IsValid) {
                _context.ResponseToEvites.Add(responseToEvite);
                _context.SaveChanges();
                return View("Thanks", responseToEvite);
            } else {
                // there is a validation error
                return View();
            }
        }

        public IActionResult ListResponses() {
            return View(_context.ResponseToEvites.Where(r => r.WillAttend == true));
        }
         public IActionResult ListNoShows() {
            return View(_context.ResponseToEvites.Where(r => r.WillAttend == false));
        }
    }
}
