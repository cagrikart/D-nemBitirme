using DönemBitirme.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DönemBitirme.Controllers
{
    public class AboutUsController : Controller
    {
        // GET: AboutUs
        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult Index()
        {
            try
            {
                var list = db.GetAboutUs().ToList();
                return View(list);
            }
            catch
            {
                return RedirectToAction("ErrorPage", "Error");
            }
        }
        [HttpGet]
        public ActionResult CreateAboutUs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAboutUs(AboutU aboutUs)
        {
            try
            {
                string str = aboutUs.Explanation;
                db.CreateAboutUs(str);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("ErrorPage", "Error");
            }
        }
        public ActionResult DeleteAboutUs(int id)
        {
            try
            {
                db.DeleteAboutUs(id);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("ErrorPage", "Error");
            }
        }
        public ActionResult ViewAboutUs(int id)
        {
            try
            {
                var aboutUs = db.AboutUs.Find(id);
                return View("ViewAboutUs", aboutUs);
            }
            catch
            {
                return RedirectToAction("ErrorPage", "Error");
            }
        }

        public ActionResult UpdateAboutUs(AboutU aboutUs)
        {
            try
            {
                db.UpdateAboutUs(aboutUs.AboutUsId, aboutUs.Explanation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("ErrorPage", "Error");
            }
        }
    }
}