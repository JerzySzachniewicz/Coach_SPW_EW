using System;
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

        public ActionResult ExcerciseList()
        {
            IEnumerable<Exercise> myList;
            using (var dbContext = new Model1())
            {
                myList = dbContext.Exercise.ToList();
            }
            return View(myList);
        }
    }
}