using DönemBitirme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DönemBitirme.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult Index()
        {
            try
            {
                var list = db.GetAuthor().ToList();
                return View(list);
            }
            catch
            {
                return RedirectToAction("ErrorPage", "Error");
            }
        }
       

        [HttpGet]
        public ActionResult CreateAuthor()
        {
            return View();

        }

        [HttpPost]
        public ActionResult CreateAuthor(Author author)
        {
            try
            {
                string str = author.AuthorName;
                db.CreateAuthor(str);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("ErrorPage", "Error");
            }
        }
        public ActionResult DeleteAuthor(int id)
        {
                db.DeleteAuthor(id);
                db.SaveChanges();
                return RedirectToAction("Index");
        }
        public ActionResult ViewAuthor(int id)
        {
            try
            {
                var author = db.Authors.Find(id);
                return View("ViewAuthor", author);
            }
            catch
            {
                return RedirectToAction("ErrorPage", "Error");
            }
        }

        public ActionResult UpdateAuthor(Author author)
        {
            try
            {
                db.UpdateAuthor(author.AuthorId, author.AuthorName);
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