using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iKonnekta_51.Controllers
{
    public class ResidentController : Controller
    {
        // GET: Resident
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
        public ActionResult NotificationPage() 
        {
            return View();
        }
    }
}