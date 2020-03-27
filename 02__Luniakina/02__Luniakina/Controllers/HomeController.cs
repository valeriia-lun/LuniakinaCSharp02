using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _02__Luniakina.Models;
using System.Web;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace _02__Luniakina.Controllers
{
    public class HomeController : Controller
    {
        Users users = new Users { UsersList = Users.GetList() };
    
        [HttpGet]
        public IActionResult Index()
        {
            
            return View(users);
        }

        [HttpPost]
        public IActionResult Index(List<Person> user)
        {
            if (ModelState.IsValid)
            {
                try {
                    Person person = new Person(HttpContext.Request.Form["Name"],
                                         HttpContext.Request.Form["LastName"],
                                         HttpContext.Request.Form["BirthDate"],
                                         HttpContext.Request.Form["EMail"]);

                  users.UsersList.Add(person);

                    return View(users);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("Error", e.Message);
                    return View(users);
                }  
            }
                else
                    return View("Index");
        }

      
    }
  
}
