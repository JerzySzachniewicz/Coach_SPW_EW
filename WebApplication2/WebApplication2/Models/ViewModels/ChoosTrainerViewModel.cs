using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.ViewModels
{
    public class ChoosTrainerViewModel
    {
        public Users recomendedTrainer;
        public IEnumerable<Users> trainers;
        public ChoosTrainerViewModel (int? planId)
        {
            using (var db = new Model1()) {
                if (planId.HasValue)
                {
                    TrainingPlan tp = db.TrainingPlan.First(p => p.PlanId == planId);
                    recomendedTrainer = db.Users.First(u => u.UsserId == tp.Coach);
                }
                else
                {
                    recomendedTrainer = null;
                }
                trainers = db.Users.Where(u => u.isTrainer == true).ToList();
            }
        }
    }
}