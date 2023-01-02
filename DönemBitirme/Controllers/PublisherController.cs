using DönemBitirme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DönemBitirme.Controllers
{
    public class PublisherController : Controller
    {
        // GET: Publisher
        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult Index()
        {
            try
            {
                var list = db.GetPublisher().ToList();
                return View(list);
            }
            catch
            {
                return RedirectToAction("ErrorPage", "Error");
            }
        }
        [HttpGet]
        public ActionResult CreatePublisher()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePublisher(Publisher publisher)
        {
            try
            {
                string str = publisher.PublisherName;
                db.CreatePublisher(str);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("ErrorPage", "Error");
            }
        }

        public ActionResult DeletePublisher(int id)
        {
            try
            {
                db.DeletePublisher(id);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("ErrorPage", "Error");
            }
        }
        public ActionResult ViewPublisher(int id)
        {
            try
            {
                var publisher = db.Publishers.Find(id);
                return View("ViewPublisher", publisher);
            }
            catch
            {
                return RedirectToAction("ErrorPage", "Error");
            }
        }

        public ActionResult UpdatePublisher(Publisher publisher)
        {
            try
            {
                db.UpdatePublisher(publisher.PublisherId, publisher.PublisherName);
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