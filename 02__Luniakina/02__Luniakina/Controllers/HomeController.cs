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
        public IActionResult IndexPost()
        {
            if (ModelState.IsValid)
            {
                Person person = new Person(HttpContext.Request.Form["Name"],
                                          HttpContext.Request.Form["LastName"],
                                          HttpContext.Request.Form["BirthDate"],
                                          HttpContext.Request.Form["EMail"]);
                try
                {
                    person.Validate();
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("Error", e.Message);
                    return View("Index");
                }

                    return View("_Age", person);
            }
                else
                    return View("Index");
        }
    }
  
}
