using CRUDMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDMVC.Controllers
{
    public class StudentController : Controller
    {
        CrudMVCEntities dbObj = new CrudMVCEntities();

        
        public ActionResult Details()
        {
            List<tbl_Student> student = dbObj.tbl_Student.ToList();
            return View(student);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            if (ModelState.IsValid)
            {
                tbl_Student std = new tbl_Student();
                TryUpdateModel(std);
                dbObj.tbl_Student.Add(std);
                TempData["AddMessage"] = "New student has been added successfully";
                dbObj.SaveChanges();
                return RedirectToAction("Details");
                //std.Name = student.Name;
                //std.Course = student.Course;
                //std.Gender = student.Gender;
                //std.Address = student.Address;
                //std.Email = student.Email;
            }
            ModelState.Clear();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            tbl_Student student = dbObj.tbl_Student.Single(m => m.ID == id);
            return View(student);
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(tbl_Student student)
        {
            if (ModelState.IsValid)
            {
                UpdateDetail detail = new UpdateDetail();
                detail.Update(student);
                TempData["UpdateMessage"] = "Data has been updated successfully";
                return RedirectToAction("Details");
                //bool check = detail.Update(student);
                //if (check == true)
                //{
                //ModelState.Clear();
                //return RedirectToAction("Details");

                //}

                //tbl_Student std = new tbl_Student();
                //TryUpdateModel(std);
                //dbObj.tbl_Student.Add(std);
            }
            return View(student);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            tbl_Student student = dbObj.tbl_Student.Single(m => m.ID == id);
            return View(student);
        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            if (ModelState.IsValid)
            {
                UpdateDetail delete = new UpdateDetail();
                delete.DeleteRecord(id);
                TempData["DeleteMessage"] = "Data deleted successfully!!";
                return RedirectToAction("Details");
            }
            return View();
        }

        public ActionResult Detail(int id)
        {
            tbl_Student student = dbObj.tbl_Student.Single(m => m.ID == id);
            return View(student);
        }


    }
}