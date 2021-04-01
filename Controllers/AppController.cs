using MailKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShoePortal_ECommerce.Data;
using OnlineShoePortal_ECommerce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoePortal_ECommerce.Controllers
{
    public class AppController: Controller
    {
        private readonly IMailService _mailService;
        //private readonly ShoeContext _context;
        private readonly IShoeRepository _repository;

        public AppController(/*IMailService mailService, ShoeContext context*/ IShoeRepository repository)
        {
            //_mailService = mailService;
            //_context = context;
            _repository = repository;
        }
        public IActionResult Index()
        {
            //var result = _context.Products.ToList();
            return View();
        }

        [Authorize]
        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Us";
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                //send email 
            }
            else
            {
                //show errors
            }
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }

        [Authorize]
        public IActionResult Shop()
        {
            ViewBag.Title = "Shop";
            var results = /*from p in _context*/_repository/*.Products*/.GetAllProducts();
                          //orderby p.Category
                          //select p;

            return View(results.ToList());
        }

    }
}
