using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iKonnekta_51.Controllers
{
    public class iKonnekta_51Controller : Controller
    {
        // GET: iKonnekta_51
        public ActionResult LoginPage()
        {
            return View();
        }
        public ActionResult ForgotPasswordPage() 
        {
            return View();
        }
        public ActionResult RegistrationPage() 
        {
                return View();
        }
        public ActionResult DashboardPage() 
        {
            return View();
        }
        public ActionResult SubmitRequestPage() 
        {
            return View();
        }
        public ActionResult HistoryPage_Resident() 
        {
            return View();
        }
        public ActionResult TrackRequestPage() 
        {
            return View();
        }
            public ActionResult ResidentProfilePage()
            {
                 return View();
            }
    }
}