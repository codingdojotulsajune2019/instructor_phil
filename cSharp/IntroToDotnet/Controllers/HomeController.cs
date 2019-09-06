using Microsoft.AspNetCore.Mvc;

namespace IntroToDotnet.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            // return "Hello World from index route!";
            ViewBag.Name = "Phil";
            return View();
        }

        [HttpGet("/process/{name}")]
        public string Process(string name)
        {
            return $"Process method, name: {name}";
        }
    }
}