using Exercise_One.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Exercise_One.Controllers
{
    public class HomeController : Controller
    {

        public List<User> usersList { get; set; }

        public HomeController()
        {
            usersList = new List<User>()
            {
                new User() { FirstName = "omer", LastName = "ali", Email = "o@o.com", Address = "nice Street", City = "london" },
                new User() { FirstName = "ali", LastName = "osama", Email = "o@o.com", Address = "bad Street", City = "paris" },
            };
        }



       

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {

            return View(usersList);
        }

        [HttpGet]
        public IActionResult Regester()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Regester(User user)
        {
            User user1 = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                City = user.City,
            };
            usersList.Add(user1);
            return RedirectToAction("Users");
        }

        [HttpGet]
        public IActionResult Calculatore()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculatore(Number number)
        {
            ViewBag.sum = number.One + number.Two;
            ViewBag.sub = number.One - number.Two;
            ViewBag.div = number.Two != 0 ?  number.One / number.Two : -1 ;
            ViewBag.mul = number.One * number.Two;


            return View();
        }

        [HttpGet]
        public IActionResult Reverse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Reverse(Person person)
        {
            var reverseName = string.Empty;

            for (int i = person.Name.Length - 1; i >= 0; i--)
            {
                reverseName += person.Name[i];
            }
            ViewBag.reverseName = reverseName;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }

}