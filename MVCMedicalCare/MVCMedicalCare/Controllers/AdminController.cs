using MVCMedicalCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMedicalCare.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            if (checkAdmin() == true)
            {
                return View();
            }
            else
            {
                return Redirect("~/Home");
            }
        }

        public bool checkAdmin() {
            if (Session["User"] == null)
            {
                return false;
            }
            else
            {
                DataMedicalDataContext database = new DataMedicalDataContext();
                string Checkuser = Session["User"].ToString();
                var OType = (from c in database.Accounts
                             where c.empno == Checkuser
                             select c).FirstOrDefault();
                if (OType.Type == "ad")
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public ActionResult AddInsurenceCom() {
            if (checkAdmin() == true)
            {
                return View();
            }
            else
            {
                return Redirect("~/Home");
            }
        }

        [HttpPost]
        public ActionResult AddCompany() {
            if (checkAdmin()==true)
            {
                DataMedicalDataContext database = new DataMedicalDataContext();
                CompanyDetail cpn = new CompanyDetail();
                cpn.CompanyName = Request.Form["name"];
                cpn.Address = Request.Form["message"];
                cpn.CompanyURL = Request.Form["subject"];
                cpn.Phone = Request.Form["field"];

                database.CompanyDetails.InsertOnSubmit(cpn);
                database.SubmitChanges();
                return Redirect("~/Admin/AddInsurenceCom");
            }
            else { 
                return Redirect("~/Home");
            }
        }

        public ActionResult AddPolicyCom() {
            if (checkAdmin() == true)
            {
                DataMedicalDataContext database = new DataMedicalDataContext();
                var listCompany = (from c in database.CompanyDetails
                                   select c).ToList();
                if (listCompany.Count() == 0)
                {
                    return Redirect("~/Admin/AddInsurenceCom");
                }
                else
                    return View(listCompany);
            }
            else {
                return Redirect("~/Home");
            }
        }

        [HttpPost]
        public ActionResult AddPolicy() {
            if (checkAdmin() == true)
            {
                DataMedicalDataContext database = new DataMedicalDataContext();
                policy plc = new policy();
                plc.policyname = Request.Form["name"];
                plc.policydes = Request.Form["descr"];
                plc.amount = Int64.Parse(Request.Form["amount"]);
                plc.Emi = Int64.Parse(Request.Form["emi"]);
                plc.companyId = Int32.Parse(Request.Form["cbbCom"]);
                database.policies.InsertOnSubmit(plc);
                database.SubmitChanges();
                return Redirect("~/Admin/AddPolicyCom");
            }
            else {
                return Redirect("~/Home");
            }
        }

        public ActionResult ViewPolicy() {
            if (checkAdmin() == true)
            {
                DataMedicalDataContext database = new DataMedicalDataContext();
                var listPolicy = (from p in database.policies
                                  join c in database.CompanyDetails on p.companyId equals c.CompanyId
                                  select new PolicyCompanyResult
                                  {
                                      PolicyId = p.policyid.ToString(),
                                      PolicyName = p.policyname,
                                      PolicyDesc = p.policydes,
                                      Amount = p.amount.ToString(),
                                      EMI = p.Emi.ToString(),
                                      CompanyId = p.companyId.ToString(),
                                      CompanyName = c.CompanyName,
                                      ComAddress = c.Address,
                                      ComPhone = c.Phone,
                                      ComUrl = c.CompanyURL

                                  }).ToList();

                return View(listPolicy);
            }
            else
            {
                return Redirect("~/Home");
            }
        }

        //public ActionResult DetailsCompany(int id) { 
        //    DataMedicalDataContext database=new DataMedicalDataContext();
        //    var com = (from c in database.CompanyDetails
        //               where c.CompanyId==id
        //              select c).ToList();

        //    return PartialView(com);

        //}
    }
}
