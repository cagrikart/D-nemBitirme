using DönemBitirme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DönemBitirme.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult Index()
        {
            try
            {
                var list = db.GetCategory().ToList();
                return View(list);
            }

            catch
            {
                return RedirectToAction("ErrorPage", "Error");
            }
        }
        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            try
            {
                string ctg = category.CategoryName;
                db.CreateCategory(ctg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("ErrorPage", "Error");
            }
        }

        public ActionResult DeleteCategory(int id)
        {
                db.DeleteCategoryProc(id);
                db.SaveChanges();
                return RedirectToAction("Index");
            
        }
        public ActionResult ViewCategory(int id)
        {
            try
            {
                var kategori = db.Categories.Find(id);
                return View("ViewCategory", kategori);
            }
            catch
            {
                return RedirectToAction("ErrorPage", "Error");
            }
        }

        public ActionResult UpdateCategory(Category category)
        {
            try
            {
                db.UpdateCategory(category.CategoryId, category.CategoryName);
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