using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DönemBitirme.Models;
namespace DönemBitirme.Controllers
{
    public class HomeController : Controller
    {
        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult Index()
        {
            var list = db.GETBOOKS().ToList();
            return View(list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}