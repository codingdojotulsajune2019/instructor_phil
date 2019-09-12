using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoDachi.Models;
using Microsoft.AspNetCore.Http;

namespace DojoDachi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            Dachi DachiOne;
            if(HttpContext.Session.GetObjectFromJson<Dachi>("Dachi") == null)
            {
                // set the dachi in session
                DachiOne = new Dachi();
                HttpContext.Session.SetObjectAsJson("Dachi", DachiOne);
            } else {
                DachiOne = HttpContext.Session.GetObjectFromJson<Dachi>("Dachi");
            }


            if(TempData["form_action"] != null)
            {
                ViewBag.FormAction = TempData["form_action"];
            }
            string result = HttpContext.Session.GetString("Result");
            // check if we won or lost
            if(result == "True")
            {
                ViewBag.Result = true;
            } else if(result == "False")
            {
                ViewBag.Result = false;
            } else {
                ViewBag.Result = null;
            }
            return View(DachiOne);
        }

        [HttpPost("dachi_play/{dachi_action}")]
        public IActionResult Process(string dachi_action)
        {
            System.Console.WriteLine("-----------------------------------------------------------------------------------");
            System.Console.WriteLine($"The form submitted was from {dachi_action}!");
            TempData["form_action"] = $"The form submitted was from {dachi_action}!";
            Dachi DachiOne = HttpContext.Session.GetObjectFromJson<Dachi>("Dachi");

            DachiOne.UpdateDachi(dachi_action);
            
             // If energy, fullness, and happiness are all raised to over 100, you win! a restart button should be displayed.
            if(DachiOne.Happiness > 100 && DachiOne.Fullness > 100 && DachiOne.Energy > 100)
            {
                // we won
                HttpContext.Session.SetString("Result", "True");
            }
            // If fullness or happiness ever drop to 0, you lose, and a restart button should be displayed.
            else if(DachiOne.Fullness < 0 || DachiOne.Fullness < 0) {
                // we lost
                HttpContext.Session.SetString("Result", "False");
            }

            HttpContext.Session.SetObjectAsJson("Dachi", DachiOne);
            return RedirectToAction("Index");
        }

        [HttpGet("restart")]
        public IActionResult Restart()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
