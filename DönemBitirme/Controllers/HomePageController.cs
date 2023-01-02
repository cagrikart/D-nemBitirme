using DönemBitirme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DönemBitirme.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult HomePage()
        {
            List<Book> books = db.Books.ToList();
            List<AboutU> abouts= db.AboutUs.ToList();

            HomePage homePage = new HomePage();

            homePage.getBooks = books;
            homePage.aboutUs = abouts;

            return View(homePage);
        }
    }
}