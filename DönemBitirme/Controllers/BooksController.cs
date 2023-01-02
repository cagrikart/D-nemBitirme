using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using DönemBitirme.Models;
namespace DönemBitirme.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books

        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult Index()
        {
            try
            {

                var list = db.GETBOOKS().ToList();
                return View(list);
            }
             catch
            {
                return RedirectToAction("ErrorPage", "Error");
            }

        }
        [HttpGet]
        public ActionResult CreateBooks()
        {
            List<SelectListItem> category = (from i in db.GetCategory().ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CategoryName,
                                               Value = i.CategoryId.ToString()
                                           }).ToList();
            ViewBag.category = category;

            List<SelectListItem> author = (from i in db.GetAuthor().ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AuthorName,
                                               Value = i.AuthorId.ToString()
                                           }).ToList();
            ViewBag.author = author;

            List<SelectListItem> publisher = (from i in db.GetPublisher().ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.PublisherName,
                                               Value = i.PublisherId.ToString()
                                           }).ToList();
            ViewBag.publisher = publisher;
          
            return View();
        }

        [HttpPost]
        public ActionResult CreateBooks(Book book)
        {
                string bookName = book.BookName;
                var category = book.Category;
                var author = book.Author;
                string bookYear = book.BookYear;
                var publisher = book.Publisher;
                db.CreateBooks(bookName, category, author, bookYear, publisher);
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        public ActionResult DeleteBooks(int id)
        {
                db.DeleteBooksProc(id);
                db.SaveChanges();
                return RedirectToAction("Index");
            try
            {
            }
             catch
            {
                return RedirectToAction("ErrorPage", "Error");
            }
        }
        public ActionResult ViewBooks(int id)
        {
            var books = db.Books.Find(id);
            List<SelectListItem> category = (from i in db.GetCategory().ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.CategoryName,
                                                 Value = i.CategoryId.ToString()
                                             }).ToList();
            ViewBag.category = category;

            List<SelectListItem> author = (from i in db.GetAuthor().ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AuthorName,
                                               Value = i.AuthorId.ToString()
                                           }).ToList();
            ViewBag.author = author;

            List<SelectListItem> publisher = (from i in db.GetPublisher().ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.PublisherName,
                                                  Value = i.PublisherId.ToString()
                                              }).ToList();
            ViewBag.publisher = publisher;
            return View("ViewBooks", books);
        }

        public ActionResult UpdateBooks(Book book)
        {
                db.UpdateBook(book.BookId, book.BookName, book.Category, book.Author, book.BookYear, book.Publisher);
                db.SaveChanges();
                return RedirectToAction("Index");
            try
            {
            }
            catch
            {
                return RedirectToAction("ErrorPage", "Error");
            }
        }
    }
}