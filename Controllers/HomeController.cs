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
                new User() { Id = 1, FirstName = "omer", LastName = "ali", Email = "o@o.com", Address = "nice Street", City = "london" },
                new User() { Id = 2,FirstName = "ali", LastName = "osama", Email = "o@o.com", Address = "bad Street", City = "paris" },
            };
        }


       

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Users()
        {
            
            return View(this.usersList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {

            //ViewBag.firstName = user.FirstName;
            //ViewBag.lastName = user.LastName;
            //ViewBag.email = user.Email;
            //ViewBag.address = user.Address;
            //ViewBag.city = user.City;
           
            this.usersList.Add(user);
            return RedirectToAction(nameof(Users));
        }

        [HttpGet]
        public IActionResult Calculatore()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculatore(Number number)
        {
            ViewBag.Result = getResult(number);
            
            return View();
        }



        public float getResult(Number number)
        {
            switch (number.Operation)
            {
                case '+': return number.One + number.Two;
                case '-': return number.One - number.Two;
                case '*': return number.One * number.Two;
                case '/': return number.Two != 0 ? number.One / number.Two : -1;
                default: return -1;
            }
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