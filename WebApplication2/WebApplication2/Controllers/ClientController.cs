using System;
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

        public ActionResult ResultsList()
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
                var playerID = int.Parse(Session["UserID"].ToString());
                var myUser = db.Users.First(u => u.UsserId == playerID);
                if (myUser.TrainingPlan == null)
                {
                    return RedirectToAction("ChoosPlan", "Client");
                }
                return View(new PlanViewModel(myUser.TrainingPlan.Value));
            }
        }

        private bool ifMe = false;

        public void test()
        {
            ifMe = !ifMe;
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
                if (ifMe)
                    myUser.Coach = 6666;
                db.SaveChanges();
            }
            return RedirectToAction("TrainingPlan", "Client");
        }
    }
}