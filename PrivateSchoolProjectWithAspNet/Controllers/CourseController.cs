using PrivateSchoolProjectWithAspNet.IRepositories;
using PrivateSchoolProjectWithAspNet.Models;
using PrivateSchoolProjectWithAspNet.MyDatabase;
using PrivateSchoolProjectWithAspNet.Repositories;
using PrivateSchoolProjectWithAspNet.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace PrivateSchoolProjectWithAspNet.Controllers
{
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ActionResult> GetCourses()
        {
            try
            {
                var courses = await _unitOfWork.Courses.GetAll();
                return View(courses);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<ActionResult> GetCourse(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                Course course = await _unitOfWork.Courses.Get(id);

                if (course == null)
                {
                    return new HttpStatusCodeResult(400, "The request is invalid.");
                }
                return View(course);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public ActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                _unitOfWork.Courses.Add(course);
                await _unitOfWork.Complete();

                return RedirectToAction("GetCourses");
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<ActionResult> EditCourse(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                var courseTask = _unitOfWork.Courses.Get(id);

                if (courseTask == null)
                {
                    return HttpNotFound();
                }

                Course course = await courseTask;
                return View(course);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> EditCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                Course cs = await _unitOfWork.Courses.Get(course.CourseId);

                cs.Title = course.Title;
                cs.Type = course.Type;
                cs.StartDate = course.StartDate;
                cs.EndDate = course.EndDate;

                _unitOfWork.Courses.ModifyEntity(cs);
                await _unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }

            return RedirectToAction("GetCourses");
        }

        public async Task<ActionResult> DeleteCourse(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                var courseTask = _unitOfWork.Courses.Get(id);

                if (courseTask == null)
                {
                    return HttpNotFound();
                }
                Course course = await courseTask;
                return View(course);
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
                var courseToDelete = await _unitOfWork.Courses.Get(id);

                if (courseToDelete == null)
                {
                    return HttpNotFound();
                }

                _unitOfWork.Courses.Remove(courseToDelete);
                await _unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }

            return RedirectToAction("GetCourses");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }


        //public ActionResult GetStudentsPerCourse()
        //{
        //    try
        //    {
        //        var courses = _unitOfWork;
        //        return View(courses);
        //    }
        //    catch (Exception error)
        //    {
        //        return Json(new { error.Message });
        //    }
        //}        
    }
}
