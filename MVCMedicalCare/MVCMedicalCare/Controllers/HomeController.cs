using MVCMedicalCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMedicalCare.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult HomePage()
        {
            if (Session["User"] !=null) {
                DataMedicalDataContext database = new DataMedicalDataContext();
                string Checkuser=Session["User"].ToString();
                var OType = (from c in database.Accounts
                             where c.empno == Checkuser
                             select c).FirstOrDefault();
                if (OType.Type == "ad")
                {
                    return Redirect("~/Admin/Index");
                }
                else
                    return Redirect("~/Member/Index");
                
            }
            else
            return View();
        }

        public ActionResult Page_login()
        {
            if (Session["User"] == null)
            {
                return View("Page_login");
            }
            else {
                return View("HomePage");
            }
        }
        [HttpPost]
        public ActionResult Login()
        {
            User checkUser = new User();
            string us = Request.Form["username"];      
            string pas = Request.Form["pass"];
            if (checkUser.IsValid(us,pas))
            {
                DataMedicalDataContext database = new DataMedicalDataContext();
                var acc= (from c in database.Accounts
                         where c.empno == us
                         select c).FirstOrDefault();

                Session["User"] = acc.empno;
                if (acc.Type == "ad")
                {
                    return Redirect("~/Admin/Index");
                }
                else
                    return Redirect("~/Member/Index");
            }
            else
            {
                TempData["Eror"] = "Login failed. Check your login details.";
                return Redirect("Page_login");
            }
            
            
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            return Redirect("~/Home");
        }

    }
}
