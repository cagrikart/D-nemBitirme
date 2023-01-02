using DönemBitirme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DönemBitirme.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult Index()
        {
            try
            {
                var list = db.GetEmployee().ToList();
                return View(list);
            }
            catch
            {
                return RedirectToAction("ErrorPage", "Error");
            }
        }
        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            try
            {
                string emp = employee.EmployeeName;
                db.CreateEmployee(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("ErrorPage", "Error");
            }
        }
        public ActionResult DeleteEmployee(int id)
        {
            try
            {
                db.DeleteEmployee(id);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("ErrorPage", "Error");
            }
        }
        public ActionResult ViewEmployee(int id)
        {
            try
            {
                var employee = db.Employees.Find(id);
                return View("ViewEmployee", employee);
            }
            catch
            {
                return RedirectToAction("ErrorPage", "Error");
            }
        }

        public ActionResult UpdateEmployee(Employee employee)
        {
            try
            {
                db.UpdateEmployee(employee.EmployeeId, employee.EmployeeName);
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