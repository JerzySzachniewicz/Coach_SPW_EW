using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models.ViewModels
{
    public class AddResult
    {
        public TrainingResult result { get; set; }
        public IEnumerable<SelectListItem> sessions;

        public AddResult()
        {            
        }

        public AddResult(int userId)
        {
            using (var db = new Model1())
            {
                var user = db.Users.First(u => u.UsserId == userId);
                var tempSesions = db.TrainingSessionsInPlan.Where(s => s.PlanId == user.TrainingPlan).ToList();
                var mySessions = new List<SelectListItem>();
                foreach (var session in tempSesions)
                {
                    var mySession = db.TrainingSession.First(s => s.SessionId == session.SessionId);
                    mySessions.Add(new SelectListItem { Text = getDayName(mySession.DayOfTraining.Value) + " session", Value = mySession.SessionId + "" });
                }
                sessions = mySessions;
            }
        }

        private string getDayName(int i)
        {
            switch (i)
            {                
                case 0:
                    return "Monday";
                case 1:
                    return "Tuesday";
                case 2:
                    return "Wednesday";
                case 3:
                    return "Thursday";
                case 4:
                    return "Friday";
                case 5:
                    return "Saturday";
                case 6:
                    return "Sunday";
            }
            return "";
        }
    }
}