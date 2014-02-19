using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMedicalCare.Controllers
{
    public class MemberController : Controller
    {
        //
        // GET: /Member/

        public ActionResult Index()
        {
            if (Session["User"] == null)
            {
                return Redirect("~/Home");
            }
            else
            return View();
        }

    }
}
