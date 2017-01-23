using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models.ViewModels
{
    public class CreatePlanViewModel
    {
        public int plan;
        public int day { get; set; }
        public ExercisesInSession exercisesInSession { get; set; }
        public IEnumerable<SelectListItem> excerciseList;
        public IEnumerable<SelectListItem> days;

        public CreatePlanViewModel()
        {            
        }

        public CreatePlanViewModel(int idPlanu)
        {
            using(var db = new Model1())
            {
                plan = db.TrainingPlan.First(p => p.PlanId == idPlanu).PlanId;
                var tempList = new List<SelectListItem>();
                foreach (var tempExcercise in db.Exercise.ToList())
                {
                    tempList.Add(new SelectListItem { Text = tempExcercise.Name, Value = tempExcercise.ExerciseId + "" });
                }
                excerciseList = tempList;
            }
            
            var temp = new List<SelectListItem>();
            temp.Add(new SelectListItem { Text = "Monday", Value = "0" });
            temp.Add(new SelectListItem { Text = "Tuesday", Value = "1" });
            temp.Add(new SelectListItem { Text = "Wednesday", Value = "2" });
            temp.Add(new SelectListItem { Text = "Thursday", Value = "3" });
            temp.Add(new SelectListItem { Text = "Friday", Value = "4" });
            temp.Add(new SelectListItem { Text = "Saturday", Value = "5" });
            temp.Add(new SelectListItem { Text = "Sunday", Value = "6" });
            
            days = temp;
        }

    }
}