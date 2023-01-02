using DönemBitirme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace DönemBitirme.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DBLibraryEntities db = new  DBLibraryEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserLogin_Result login)
        {
            var bilgiler = db.Members.FirstOrDefault(x => x.MemberMail == login.MemberMail && x.MemberPassword == login.MemberPassword);
            if (bilgiler == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return RedirectToAction("Index","Books");
        }
    }
}