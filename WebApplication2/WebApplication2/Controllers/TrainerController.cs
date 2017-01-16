﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class TrainerController : Controller
    {
        // GET: Trainer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateExcercise()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult CreateExcercise(Exercise ex)
        {
            if (ModelState.IsValid)
            {
                using (var dbContext = new Model1())
                {
                    dbContext.Exercise.Add(ex);
                    dbContext.SaveChanges();
                }
            }
            ModelState.Clear();
            return RedirectToAction("ExcerciseList", "Trainer");
        }

        public ActionResult ExcerciseList()
        {
            IEnumerable<Exercise> myList;
            using (var dbContext = new Model1())
            {
                myList = dbContext.Exercise.ToList();
            }
            return View(myList);
        }

        public ActionResult TrainingPlanList()
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

        public ActionResult TrainingTypeList()
        {
            IEnumerable<TrainingType> myList;

            using (var dbContext = new Model1())
            {
                myList = dbContext.TrainingType.ToList();
            }
            return View(myList);
        }

        public ActionResult TrainingTypeCreate()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult TrainingTypeCreate(TrainingType tt)
        {
            if (ModelState.IsValid)
            {
                using (var dbContext = new Model1())
                {
                    dbContext.TrainingType.Add(tt);
                    dbContext.SaveChanges();
                }
            }
            ModelState.Clear();
            return RedirectToAction("TrainingPlanList", "Trainer");
        }


    }
}