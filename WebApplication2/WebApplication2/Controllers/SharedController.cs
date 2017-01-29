using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
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
        
        public ActionResult Messanger(int id2 )
        {
            Session["Reciver"] = id2;
            var model = new MessangerViewModel(int.Parse(Session["UserID"].ToString()), id2);
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Messanger(MessangerViewModel ms)
        {
            using (var db = new Model1())
            {
                var id = int.Parse(Session["UserID"].ToString());
                ms.NewMessage.SenderId = id;
                ms.NewMessage.ReciverId = int.Parse(Session["Reciver"].ToString());
                ms.NewMessage.IsRead = false;
                ms.NewMessage.MessageId = Messages.GenerateId();
                ms.NewMessage.Date = DateTime.Now;
                db.Messages.Add(ms.NewMessage);
                db.SaveChanges();

            }
            return RedirectToAction("Messanger", new {id2 = int.Parse(Session["Reciver"].ToString()) });
        }
        
    }
}