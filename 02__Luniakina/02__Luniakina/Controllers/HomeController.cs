using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _02__Luniakina.Models;

namespace _02__Luniakina.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Person person)
        {
           if(Person.CalculateAge(person.BirthDate) >= 135) {
                ModelState.AddModelError("Error", "WRONG DATE! Write the correct date of birth, please!");
                return View();
            } else if (ModelState.IsValid)
                return View("_Age", person);
            else
                return View();
        }
    }
    
}
