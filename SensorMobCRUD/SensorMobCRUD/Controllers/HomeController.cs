using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SensorMobCRUD.Models;

namespace SensorMobCRUD.Controllers
{
    [Route("measurment")]
    public class HomeController : Controller
    {
        private DataContext db = new DataContext();

        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            //ViewBag.
            //ViewBag.measurments = db.Measurments.ToList();
            ViewBag.Title = "Put yr page title here";
            ViewBag.Description = "Put your page description here";
            ViewBag.Measurments = "Hi Kuba, its your ViewBag.Measurments!";
            ViewBag.Measurments = db.Measurments.ToList();

            return View();
        }

        [HttpGet]
        [Route("Add")]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(Measurment measurment)
        {
            db.Measurments.Add(measurment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.Measurments.Remove(db.Measurments.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            return View("Edit", db.Measurments.Find(id));
        }

        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, Measurment measurment)
        {
            db.Entry(measurment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }








        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
