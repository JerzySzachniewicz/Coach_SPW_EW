using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.ViewModels
{
    public class ResultsViewModel
    {
        public Users user;
        public IEnumerable<Results> Results;
        public IEnumerable<TrainingResult> TrainingResultsResult;

        public ResultsViewModel(int id)
        {
            using (var db = new Model1())
            {
                user = db.Users.First(u => u.UsserId == id);
                Results = db.Results.Where(r => r.Users_Id.Value == id).ToList();
                TrainingResultsResult = db.TrainingResult.Where(r => r.UserId == id).ToList();
            }
        }
    }
}