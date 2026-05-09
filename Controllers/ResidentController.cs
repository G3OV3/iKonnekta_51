using iKonnekta_51.Models;
using iKonnekta_51.Models.Context;
using iKonnekta_51.Models.Tables;
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
        // submit request
        public JsonResult getResidentInfo(int residentId)
        {
            try
            {
                using (var db = new IKONNEKTA51Context())
                {

                    var resident = (

                        from r in db.tbl_Residents

                        join rd in db.tbl_Resident_Details
                        on r.Resident_Details_ID equals rd.Resident_Details_ID

                        join rf in db.tbl_Resident_Fullname
                        on rd.Resident_FullName_ID equals rf.Resident_FullName_ID

                        join rb in db.tbl_Resident_Birth_Details
                        on rd.Resident_Birth_ID equals rb.Resident_Birth_ID

                        where r.Resident_ID == residentId

                        select new
                        {
                            firstName = rf.First_Name,
                            lastName = rf.Last_Name,

                            address = rb.Birth_Place,

                            contact = r.Contact_Number
                        }

                    ).FirstOrDefault();

                    return Json(resident, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                errorHandlerClass.errorHandler(
                    ex.StackTrace,
                    ex.InnerException?.ToString(),
                    ex.Message
                );

                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult submitDocumentRequest(tbl_document_requests_model requestData)
        {
            try
            {
                using (var db = new IKONNEKTA51Context())
                {

                    var existingCount = db.tbl_Document_Requests

                        .Count(x =>

                            x.Resident_ID == requestData.Resident_ID &&

                            x.Document_Type_ID == requestData.Document_Type_ID
                        );

                    if (existingCount >= 3)
                    {
                        return Json(new
                        {
                            success = false,
                            message = "You can only request the same document 3 times."
                        });
                    }

                    var request = new tbl_document_requests_model()
                    {
                        Resident_ID = requestData.Resident_ID,

                        Document_Type_ID = requestData.Document_Type_ID,

                        Purpose_ID = requestData.Purpose_ID,

                        Quantity = requestData.Quantity,

                        Priority_Level_ID = requestData.Priority_Level_ID,

                        Request_Status_ID = 1,

                        Created_At = DateTime.Now,

                        Edited_At = DateTime.Now
                    };

                    db.tbl_Document_Requests.Add(request);

                    db.SaveChanges();

                    return Json(new
                    {
                        success = true,
                        message = "Document request submitted successfully."
                    });
                }
            }
            catch (Exception ex)
            {
                errorHandlerClass.errorHandler(
                    ex.StackTrace,
                    ex.InnerException?.ToString(),
                    ex.Message
                );

                return Json(new
                {
                    success = false,
                    message = "An error occurred"
                });
            }
        }
        // tracking request
        public JsonResult getTrackingRequests(int residentId)
        {
            try
            {
                using (var db = new IKONNEKTA51Context())
                {
                    var data = (
                        from r in db.tbl_Document_Requests
                        join t in db.tbl_Document_Types
                            on r.Document_Type_ID equals t.Document_Type_ID
                        join p in db.tbl_Request_Purposes
                            on r.Purpose_ID equals p.Purpose_ID
                        join s in db.tbl_Document_Request_Status
                            on r.Request_Status_ID equals s.Request_Status_ID
                        join res in db.tbl_Residents
                            on r.Resident_ID equals res.Resident_ID
                        where r.Resident_ID == residentId
                              && r.Request_Status_ID == 1 
                        orderby r.Created_At descending

                        select new
                        {
                            requestId = r.Document_Request_ID,
                            documentType = t.Document_Name,
                            status = s.Request_Status_Description,
                            purpose = p.Purpose_Description,
                            submittedDate = r.Created_At,
                            contact = res.Contact_Number,
                            estimatedCompletion = s.Estimation_Completion_Time
                        }
                    ).ToList();

                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                errorHandlerClass.errorHandler(ex.StackTrace, ex.InnerException?.ToString(), ex.Message);

                return Json(new { success = false });
            }
        }
        public JsonResult cancelRequest(int requestId)
        {
            try
            {
                using (var db = new IKONNEKTA51Context())
                {
                    var request = db.tbl_Document_Requests.FirstOrDefault(x => x.Document_Request_ID == requestId);

                    if (request == null)
                    {
                        return Json(new { success = false, message = "Not found" });
                    }
                    if (request.Request_Status_ID != 1)
                    {
                        return Json(new { success = false, message = "Cannot cancel this request" });
                    }

                    request.Request_Status_ID = 4;
                    request.Edited_At = DateTime.Now;

                    db.SaveChanges();

                    return Json(new { success = true });
                }
            }
            catch (Exception ex)
            {
                errorHandlerClass.errorHandler(ex.StackTrace, ex.InnerException?.ToString(), ex.Message);

                return Json(new { success = false });
            }
        }

    }
}