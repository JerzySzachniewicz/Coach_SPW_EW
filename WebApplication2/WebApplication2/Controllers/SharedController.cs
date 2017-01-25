using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Models.ViewModels;

namespace WebApplication2.Controllers
{
    public class SharedController : Controller
    {
        // GET: Shared
        public ActionResult DetilesPlan(int id)
        {
            return View(new PlanViewModel(id));
        }


        public ActionResult ResultsList(int id)
        {
            return View(new ResultsViewModel(id));
        }

        public ActionResult Messanger()
        {
            IEnumerable<Messages> list;
            using (var db = new Model1())
            {
                list = db.Messages.ToList();
            }
            return View(list);
        }
    }
}