//Bao Tran
//Homework 6

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayCard.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RsvpForm(Models.BirthdayResponse sentReponse)
        {
            if (ModelState.IsValid)
            {
                return View("SentReponse", sentReponse);
            }
            else
            {
                return View();
            }            
        }


    }
}