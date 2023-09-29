using PrivateSchoolProjectWithAspNet.IRepositories;
using PrivateSchoolProjectWithAspNet.Models;
using PrivateSchoolProjectWithAspNet.MyDatabase;
using PrivateSchoolProjectWithAspNet.Repositories;
using PrivateSchoolProjectWithAspNet.Unit;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PrivateSchoolProjectWithAspNet.Controllers
{
    public class StudentController : System.Web.Mvc.Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ActionResult> GetStudents()
        {
            try
            {
                var students = await _unitOfWork.Students.GetAll();
                return View(students);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<ActionResult> GetStudent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                Student student = await _unitOfWork.Students.Get(id);

                if (student == null)
                {
                    return new HttpStatusCodeResult(400, "The request is invalid.");
                }
                return View(student);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public ActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                _unitOfWork.Students.Add(student);
                await _unitOfWork.Complete();

                return RedirectToAction("GetStudents");
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        public async Task<ActionResult> EditStudent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                var studentTask = _unitOfWork.Students.Get(id);

                if (studentTask == null)
                {
                    return HttpNotFound();
                }

                Student student = await studentTask;
                return View(student);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> EditStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                Student stu = await _unitOfWork.Students.Get(student.StudentId);

                stu.FirstName = student.FirstName;
                stu.LastName = student.LastName;
                stu.DateOfBirth = student.DateOfBirth;
                stu.TuitionFees = student.TuitionFees;

                _unitOfWork.Students.ModifyEntity(stu);
                await _unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }          

            return RedirectToAction("GetStudents");
        }

        public async Task<ActionResult> DeleteStudent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                var studentTask = _unitOfWork.Students.Get(id);

                if (studentTask == null)
                {
                    return HttpNotFound();
                }

                Student student = await studentTask;
                return View(student);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }            
        }


        [HttpPost]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                var studentToDelete = await _unitOfWork.Students.Get(id);

                if (studentToDelete == null)
                {
                    return HttpNotFound();
                }

                _unitOfWork.Students.Remove(studentToDelete);
                await _unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);

            }
            return RedirectToAction("GetStudents");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        //public ActionResult getLongestLastnameStudent()
        //{
        //    try
        //    {
        //        var stuLongestName = _unitOfWork.Students.GetStudentWithLongestLastName();
        //        return Json(stuLongestName.LastName, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception error)
        //    {
        //        return Json(new { error.Message });
        //    }            
        //}


        //public ActionResult GetFirstStudent()
        //{
        //    try
        //    {
        //        var firstStudent = _unitOfWork.Students.GetFirstStudent();
        //        return Json(firstStudent, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception error)
        //    {
        //        return Json(new { error.Message });
        //    }            
        //}

        //public ActionResult CreateRandomStudent()
        //{
        //    try
        //    {
        //        _unitOfWork.Students.CreateRandomStudent();

        //        var obj = new { Success = true };

        //        return Json(obj, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception error)
        //    {
        //        return Json(new { error.Message });
        //    }            
        //}       
    }
}
