﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Models.ViewModels;

namespace WebApplication2.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult AddMyInformations()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMyInformations(Results result)
        {
            if (ModelState.IsValid)
            {
                using (var db = new Model1())
                {
                    result.ResultId = Results.GenerateId();
                    result.Users_Id = int.Parse(Session["UserID"].ToString());
                    db.Results.Add(result);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("AddMyInformations", "Client");
        }

        public ActionResult TrainingPlan()
        {

            using (var db = new Model1())
            {
                var playerId = int.Parse(Session["UserID"].ToString());
                var myUser = db.Users.First(u => u.UsserId == playerId);
                if (myUser.TrainingPlan == null)
                {
                    return RedirectToAction("ChoosPlan", "Client");
                }
                return View(new PlanViewModel(myUser.TrainingPlan.Value));
            }
        }

        
        public ActionResult ChoosPlan()
        {
            IEnumerable<TrainingPlan> myList;

            using (var dbContext = new Model1())
            {
                myList = dbContext.TrainingPlan.ToList();
                foreach (var tp in myList)
                {
                    if (tp.Type.HasValue)
                    {
                        tp.TrainingType = dbContext.GetTrainingTypeBtId(tp.Type.Value);
                    }
                }
            }
            return View(myList);
        }

        
        public ActionResult ChoosPlanNow(int id)
        {
            using (var db = new Model1())
            {
                var playerId = int.Parse(Session["UserID"].ToString());
                var myUser = db.Users.First(u => u.UsserId == playerId);
                myUser.TrainingPlan = id;               
                db.SaveChanges();
            }
            return RedirectToAction("TrainingPlan", "Client");
        }

        public ActionResult UnSelectPlan()
        {
            using (var db = new Model1())
            {
                var playerId = int.Parse(Session["UserID"].ToString());
                var myUser = db.Users.First(u => u.UsserId == playerId);
                myUser.TrainingPlan = null;                
                db.SaveChanges();
            }
            return RedirectToAction("ChoosPlan", "Client");
        }

        public ActionResult Trainer()
        {
            using (var db = new Model1())
            {
                var playerId = int.Parse(Session["UserID"].ToString());
                var myUser = db.Users.First(u => u.UsserId == playerId);
                if(myUser.Coach == null)
                {
                    return RedirectToAction("ChoosTrainer", "Client");
                }
                return RedirectToAction("Messanger", "Shared", new { id2 = myUser.Coach });
            }
        }

        public ActionResult ChoosTrainer()
        {
            using (var db = new Model1())
            {
                var playerId = int.Parse(Session["UserID"].ToString());
                var myUser = db.Users.First(u => u.UsserId == playerId);
                return View(new ChoosTrainerViewModel(myUser.TrainingPlan));
            }
        }

        public ActionResult ChoosTrainerNow(int id)
        {
            using (var db = new Model1())
            {
                var playerId = int.Parse(Session["UserID"].ToString());
                var myUser = db.Users.First(u => u.UsserId == playerId);
                myUser.Coach = id;
                db.SaveChanges();              
            }
            return RedirectToAction("Trainer", "Client");
        }

        public ActionResult AddTrainingResult()
        {
            return View(new AddResult(int.Parse(Session["UserID"].ToString())));
        }

        [HttpPost]
        public ActionResult AddTrainingResult(AddResult AddResult)
        {
            if(ModelState.IsValid)
            {
                using (var db = new Model1())
                {
                    AddResult.result.ResultId = TrainingResult.GenerateId();
                    AddResult.result.UserId = int.Parse(Session["UserID"].ToString());
                    db.TrainingResult.Add(AddResult.result);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("TrainingPlan", "Client");
        }

        public ActionResult PlanHelper()
        {
            using (var db = new Model1())
            {
                var playerId = int.Parse(Session["UserID"].ToString());
                var result = db.Results.FirstOrDefault(r => r.Users_Id == playerId);
                if (result == null)
                {
                    return RedirectToAction("NoResult", "Client");
                }
                return View(new PlanHelperViewModel(result));
            }
        }

        public ActionResult NoResult()
        {
            return View();
        }
    }
}