using DönemBitirme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DönemBitirme.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult Index()
        {
            try
            {
                var list = db.GetMember().ToList();
                return View(list);
            }

            catch
            {
                return RedirectToAction("ErrorPage", "Error");
            }
        }
        [HttpGet]
        public ActionResult CreateMember()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateMember(Member member)
        {
            try
            {
                var memName = member.MemberName;
                var memMail = member.MemberMail;
                var memPass = member.MemberPassword;
                db.CreateMember(memName, memMail, memPass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("ErrorPage", "Error");
            }
        }

        public ActionResult DeleteMember(int id)
        {
            try
            {
                db.DeleteMember(id);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("ErrorPage", "Error");
            }
        }
        public ActionResult ViewMember(int id)
        {
            try
            {
                var member = db.Members.Find(id);
                return View("ViewMember", member);
            }
            catch
            {
                return RedirectToAction("ErrorPage", "Error");
            }
        }

        public ActionResult UpdateMember(Member member)
        {
            try
            {
                db.UpdateMember(member.MemberId, member.MemberName, member.MemberMail, member.MemberPassword);
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