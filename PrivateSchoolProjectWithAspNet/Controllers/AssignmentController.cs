using PrivateSchoolProjectWithAspNet.IRepositories;
using PrivateSchoolProjectWithAspNet.Models;
using PrivateSchoolProjectWithAspNet.MyDatabase;
using PrivateSchoolProjectWithAspNet.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PrivateSchoolProjectWithAspNet.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssignmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ActionResult> GetAssignments()
        {
            try
            {
                var assignments = await _unitOfWork.Assignments.GetAll();
                return View(assignments);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<ActionResult> GetAssignment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                var assignment = await _unitOfWork.Assignments.Get(id);
                if (assignment == null)
                {
                    return new HttpStatusCodeResult(400, "The request is invalid.");
                }
                return View(assignment);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public ActionResult CreateAssignment()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> CreateAssignment(Assignment assignment)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                _unitOfWork.Assignments.Add(assignment);
                await _unitOfWork.Complete();

                return RedirectToAction("GetAssignments");
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<ActionResult> EditAssignment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                var assignTask = _unitOfWork.Assignments.Get(id);

                if (assignTask == null)
                {
                    return HttpNotFound();
                }

                Assignment assign = await assignTask;
                return View(assign);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }            
        }

        [HttpPost]
        public async Task<ActionResult> EditAssignment(Assignment assignment)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                Assignment assign = await _unitOfWork.Assignments.Get(assignment.AssignmentId);

                assign.SubDateTime = assignment.SubDateTime;
                assign.Title = assignment.Title;
                assign.Description = assignment.Description;
                assign.OralMark = assignment.OralMark;
                assign.TotalMark = assignment.TotalMark;

                _unitOfWork.Assignments.ModifyEntity(assign);
                await _unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }

            return RedirectToAction("GetAssignments");
        }

        public async Task<ActionResult> DeleteAssignment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                var assignTask = _unitOfWork.Assignments.Get(id);

                if (assignTask == null)
                {
                    return HttpNotFound();
                }

                Assignment assign = await assignTask;
                return View(assign);
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
                var assignmentToDelete = await _unitOfWork.Assignments.Get(id);

                if (assignmentToDelete == null)
                {
                    return HttpNotFound();
                }

                _unitOfWork.Assignments.Remove(assignmentToDelete);
                await _unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }
            return RedirectToAction("GetAssignments");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
