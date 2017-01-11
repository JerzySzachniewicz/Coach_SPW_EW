using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
       

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Users userAccount)
        {
            if (ModelState.IsValid)
            {
                using (var dbContext = new Model1())
                {
                    dbContext.Users.Add(userAccount);
                    userAccount.isTrainer = false;
                    dbContext.SaveChanges();
                }
            }
            ModelState.Clear();
            ViewBag.Message = userAccount.Nick + " sucesfully registered!";
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users user)
        {
            using (var dbContext = new Model1())
            {
                var usr = dbContext.Users.Where(u => u.Nick == user.Nick && u.Password == user.Password).FirstOrDefault();
                if (usr != null)
                {
                    Session["UserID"] = usr.UsserId.ToString();
                    Session["UserNick"] = usr.Nick.ToString();
                    Session["isTreiner"] = usr.isTrainer.ToString();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Password or Nick is wrong!");
                }
            }
            return View();
        }
    }
}