using iKonnekta_51.Models;
using iKonnekta_51.Models.Context;
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
        public JsonResult getResidentDashboardStats(int residentId)
        {
            try
            {
                using (var db = new IKONNEKTA51Context())
                {
                    var data = (from r in db.tbl_Document_Requests
                                join s in db.tbl_Document_Request_Status
                                on r.Request_Status_ID equals s.Request_Status_ID
                                where r.Resident_ID == residentId
                                select new
                                {
                                    r.Request_Status_ID,
                                    s.Request_Status_Description
                                }).ToList();

                    var result = new
                    {
                        total = data.Count,

                        processing = data.Count(x => x.Request_Status_ID == 1),

                        ready = data.Count(x => x.Request_Status_ID == 2),

                        completed = data.Count(x => x.Request_Status_ID == 3)
                    };

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                errorHandlerClass.errorHandler(ex.StackTrace, ex.InnerException?.ToString(), ex.Message);
                return Json(new { total = 0, processing = 0, ready = 0, completed = 0 });
            }
        }
        public JsonResult getRecentRequestList(int residentId)
        {
            try
            {
                using (var db = new IKONNEKTA51Context())
                {
                    var data = (from r in db.tbl_Document_Requests
                                join t in db.tbl_Document_Types
                                    on r.Document_Type_ID equals t.Document_Type_ID
                                join p in db.tbl_Request_Purposes
                                    on r.Purpose_ID equals p.Purpose_ID
                                join s in db.tbl_Document_Request_Status
                                    on r.Request_Status_ID equals s.Request_Status_ID
                                where r.Resident_ID == residentId
                                orderby r.Created_At descending
                                select new
                                {
                                    Request = r,
                                    DocumentType = t,
                                    Purpose = p,
                                    Status = s
                                })
                                .Take(3)
                                .ToList();

                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                errorHandlerClass.errorHandler(ex.StackTrace, ex.InnerException?.ToString(), ex.Message);
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}