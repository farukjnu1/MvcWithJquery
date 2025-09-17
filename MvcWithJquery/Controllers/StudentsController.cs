using MvcWithJquery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWithJquery.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Student student)
        {
            var ctx = new TestDBEntities();
            var objStudent = ctx.Students.Add(student);
            ctx.SaveChanges();
            return Json(objStudent);
        }

        [HttpPost]
        public ActionResult Update(Student student)
        {
            var ctx = new TestDBEntities();
            var objStudent = ctx.Students.Where(w => w.StudentID == student.StudentID).FirstOrDefault();
            if (objStudent != null)
            {
                objStudent.StudentName = student.StudentName;
                objStudent.Address = student.Address;
                ctx.SaveChanges();
            }
            return Json(objStudent);
        }


        [HttpGet]
        public ActionResult GetAll()
        {
            var ctx = new TestDBEntities();
            var listStudent = ctx.Students.ToList();
            return Json(listStudent, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetById(int id)
        {
            var ctx = new TestDBEntities();
            var objStudent = ctx.Students.Where(w=>w.StudentID == id).FirstOrDefault();
            return Json(objStudent, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Remove(int id)
        {
            var ctx = new TestDBEntities();
            var objStudent = ctx.Students.Where(w => w.StudentID == id).FirstOrDefault();
            if (objStudent != null)
            {
                ctx.Students.Remove(objStudent);
                ctx.SaveChanges();
            }
            return Json(objStudent, JsonRequestBehavior.AllowGet);
        }

    }
}