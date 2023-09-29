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
    public class TrainerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ActionResult> GetTrainers()
        {
            try
            {
                var trainers = await _unitOfWork.Trainers.GetAll();
                return View(trainers);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<ActionResult> GetTrainer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                Trainer trainer = await _unitOfWork.Trainers.Get(id);

                if (trainer == null)
                {
                    return HttpNotFound();
                }
                return View(trainer);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        public ActionResult CreateTrainer()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateTrainer(Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                _unitOfWork.Trainers.Add(trainer);
                await _unitOfWork.Complete();

                return RedirectToAction("GetTrainers");
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<ActionResult> EditTrainer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                var trainerTask = _unitOfWork.Trainers.Get(id);

                if (trainerTask == null)
                {
                    return HttpNotFound();
                }

                Trainer trainer = await trainerTask;
                return View(trainer);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult> EditTrainer(Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                Trainer tr = await _unitOfWork.Trainers.Get(trainer.TrainerId);

                tr.Age = trainer.Age;
                tr.FirstName = trainer.FirstName;
                tr.LastName = trainer.LastName;

                _unitOfWork.Trainers.ModifyEntity(tr);
                await _unitOfWork.Complete();
            }
            catch(Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }           

            return RedirectToAction("GetTrainers");
        }

        public async Task<ActionResult> DeleteTrainer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var trainerTask = _unitOfWork.Trainers.Get(id);

                if (trainerTask == null)
                {
                    return HttpNotFound();
                }

                Trainer trainer = await trainerTask;

                return View(trainer);
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
                var trainerToDelete = await _unitOfWork.Trainers.Get(id);

                if (trainerToDelete == null)
                {
                    return HttpNotFound();
                }

                _unitOfWork.Trainers.Remove(trainerToDelete);
                await _unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }

            return RedirectToAction("GetTrainers");
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
