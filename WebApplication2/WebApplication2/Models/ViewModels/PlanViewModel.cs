using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.ViewModels
{
    public class PlanViewModel
    {
        public int IdPlanu;
        public IEnumerable<TrainingSessionsInPlan> TrainingSessionsInPlans;
        public SessionInPlanViewModel[] TrainingSessions = new SessionInPlanViewModel[7];

        public PlanViewModel(int planId)
        {
            IdPlanu = planId;
            using (var db = new Model1())
            {
                TrainingSessionsInPlans = db.TrainingSessionsInPlan.Where(t => t.PlanId == planId).ToList();
                foreach (var myTrainingSession in TrainingSessionsInPlans)
                {
                    var temp = new SessionInPlanViewModel(myTrainingSession.SessionId);
                    TrainingSessions[temp.TrainingSession.DayOfTraining.GetValueOrDefault(0)] = temp;
                }
                
            }
        }
    }


    public class SessionInPlanViewModel
    {
        public TrainingSession TrainingSession;
        public IEnumerable<ExercisesInSession> ExercisesInSessions;

        public SessionInPlanViewModel(int trainingSessionId)
        {
            using (var db = new Model1())
            {
                TrainingSession = db.TrainingSession.First(t => t.SessionId == trainingSessionId);
                ExercisesInSessions = db.ExercisesInSession.Where(e => e.SessionId == TrainingSession.SessionId).ToList();
            }
        }
    }
}