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
    public class VStaffController : Controller
    {
        // GET: VStaff
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VDashboardViewPage()
        {
            return View();
        }
        public ActionResult VManageRequestViewPage()
        {
            return View();
        }
        public ActionResult VRequestHistory_RecordsViewPage()
        {
            return View();
        }
        public ActionResult VRegisteredResidentsViewPage()
        {
            return View();
        }
        public ActionResult VArchivesViewPage()
        {
            return View();
        }
        public ActionResult VNotificationViewPage()
        {
            return View();
        }
        public ActionResult VListofResidentsViewPage()
        {
            return View();
        }
        public ActionResult VAddResidentViewPage()
        {
            return View();
        }
        public ActionResult VViewEditResidentInfoViewPage()
        {
            return View();
        }
        public ActionResult VViewRequestDetailsViewPage()
        {
            return View();
        }

        // Inserting Resident

        public JsonResult GetListOfResidents()
        {
            try
            {
                using (var db = new IKONNEKTA51Context())
                {
                    var getListOfResidents = (from resident in db.tbl_Residents
                                              join details in db.tbl_Resident_Details
                                                  on resident.Resident_Details_ID equals details.Resident_Details_ID
                                              join fullname in db.tbl_Resident_Fullname
                                                  on details.Resident_FullName_ID equals fullname.Resident_FullName_ID
                                              join status in db.tbl_Resident_Status
                                                  on resident.Resident_Status_ID equals status.Resident_Status_ID
                                              where resident.Resident_Status_ID !=2  // ← only this line added
                                              select new
                                              {
                                                  resident.Resident_ID,
                                                  resident.PhySys_Card_No,
                                                  resident.Contact_Number,
                                                  resident.Email_Address,
                                                  resident.Date_Registered,
                                                  resident.Resident_Details_ID,
                                                  resident.Resident_Status_ID,
                                                  resident.Created_At,
                                                  resident.Edited_At,
                                                  fullname.Last_Name,
                                                  fullname.First_Name,
                                                  fullname.Middle_Name,
                                                  fullname.Suffix
                                              }).ToList();

                    return Json(new { success = true, data = getListOfResidents }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                errorHandlerClass.errorHandler(
                    ex.StackTrace,
                    ex.InnerException?.ToString(),
                    ex.Message
                );
                return Json(new { success = false, message = "An error occurred" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetRegisteredAccounts()
        {
            try
            {
                using (var db = new IKONNEKTA51Context())
                {
                    var getResidentAccounts = (from account in db.tbl_Users
                                               join resident in db.tbl_Residents
                                                   on account.Resident_ID equals resident.Resident_ID
                                               join details in db.tbl_Resident_Details
                                                   on resident.Resident_Details_ID equals details.Resident_Details_ID
                                               join fullname in db.tbl_Resident_Fullname
                                                   on details.Resident_FullName_ID equals fullname.Resident_FullName_ID
                                               join role in db.tbl_User_Roles
                                                   on account.Role_ID equals role.Role_ID
                                               join status in db.tbl_User_Account_Status
                                                   on account.Account_Status_ID equals status.Account_Status_ID
                                               select new
                                               {
                                                   account.User_ID,
                                                   account.Resident_ID,
                                                   account.Username,
                                                   account.Last_Login,
                                                   account.Created_At,
                                                   account.Updated_At,
                                                   resident.PhySys_Card_No,
                                                   fullname.Last_Name,
                                                   fullname.First_Name,
                                                   fullname.Middle_Name,
                                                   fullname.Suffix,
                                                   Role_Name = role.Role_Description,        // use the label column, not the ID
                                                   Account_Status = status.Account_Status_Description  // renamed to match frontend
                                               }).ToList();

                    return Json(new { success = true, data = getResidentAccounts }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                errorHandlerClass.errorHandler(
                  ex.StackTrace,
                  ex.InnerException?.ToString(),
                  ex.Message
              );
                return Json(new { success = false, message = "An error occurred" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult markAsArchive(int residentStatusID) 
        {
            try 
            {
                using (var db = new IKONNEKTA51Context())
                {
                    var listOfResident = db.tbl_Residents.Find(residentStatusID);
                    if (listOfResident != null)
                    {
                        listOfResident.Resident_Status_ID = 2;
                        listOfResident.Edited_At = DateTime.Now;
                        db.SaveChanges();
                    }
                    return Json("Success", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                errorHandlerClass.errorHandler(
                  ex.StackTrace,
                  ex.InnerException?.ToString(),
                  ex.Message
              );
                return Json(new { success = false, message = "An error occurred" }, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult GetListOfArchives()
        {
            try
            {
                using (var db = new IKONNEKTA51Context())
                {
                    var getListOfResidents = (from resident in db.tbl_Residents
                                              join details in db.tbl_Resident_Details
                                                  on resident.Resident_Details_ID equals details.Resident_Details_ID
                                              join fullname in db.tbl_Resident_Fullname
                                                  on details.Resident_FullName_ID equals fullname.Resident_FullName_ID
                                              join status in db.tbl_Resident_Status
                                                  on resident.Resident_Status_ID equals status.Resident_Status_ID
                                              where resident.Resident_Status_ID != 1  
                                              select new
                                              {
                                                  resident.Resident_ID,
                                                  resident.PhySys_Card_No,
                                                  resident.Contact_Number,
                                                  resident.Email_Address,
                                                  resident.Date_Registered,
                                                  resident.Resident_Details_ID,
                                                  resident.Resident_Status_ID,
                                                  resident.Edited_At,
                                                  fullname.Last_Name,
                                                  fullname.First_Name,
                                                  fullname.Middle_Name,
                                                  fullname.Suffix
                                              }).ToList();

                    return Json(new { success = true, data = getListOfResidents }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                errorHandlerClass.errorHandler(
                    ex.StackTrace,
                    ex.InnerException?.ToString(),
                    ex.Message
                );
                return Json(new { success = false, message = "An error occurred" }, JsonRequestBehavior.AllowGet);
            }
        }
        // Dashboard
        public JsonResult getStaffDashboardStats()
        {
            try
            {
                using (var db = new IKONNEKTA51Context())
                {
                    var data = (
                        from r in db.tbl_Document_Requests

                        join s in db.tbl_Document_Request_Status
                            on r.Request_Status_ID equals s.Request_Status_ID

                        join pg in db.tbl_request_progress
                            on s.Progress_ID equals pg.Progress_ID

                        select new
                        {
                            progressId = pg.Progress_ID,
                            createdAt = r.Created_At
                        }
                    ).ToList();

                    var today = DateTime.Now.Date;

                    var result = new
                    {
                        total = data.Count,

                        processing = data.Count(x => x.progressId == 1),

                        waitingPickup = data.Count(x => x.progressId == 2),

                        completed = data.Count(x => x.progressId == 3),

                        todayWorkload = data.Count(x => x.createdAt >= today)
                    };

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                errorHandlerClass.errorHandler(ex.StackTrace, ex.InnerException.ToString(), ex.Message);
                return Json(new
                {
                    total = 0,
                    processing = 0,
                    waitingPickup = 0,
                    completed = 0,
                    todayWorkload = 0
                });
            }
        }
        public JsonResult GetAllRecentRequests()
        {
            try
            {
                using (var db = new IKONNEKTA51Context())
                {
                    var data = (
                        from r in db.tbl_Document_Requests

                        join t in db.tbl_Document_Types
                            on r.Document_Type_ID equals t.Document_Type_ID into tGroup
                        from t in tGroup.DefaultIfEmpty()

                        join p in db.tbl_Request_Purposes
                            on r.Purpose_ID equals p.Purpose_ID into pGroup
                        from p in pGroup.DefaultIfEmpty()

                        join s in db.tbl_Document_Request_Status
                            on r.Request_Status_ID equals s.Request_Status_ID into sGroup
                        from s in sGroup.DefaultIfEmpty()

                        join pg in db.tbl_request_progress
                            on s.Progress_ID equals pg.Progress_ID into pgGroup
                        from pg in pgGroup.DefaultIfEmpty()

                        join res in db.tbl_Residents
                            on r.Resident_ID equals res.Resident_ID into resGroup
                        from res in resGroup.DefaultIfEmpty()

                        orderby r.Created_At descending

                        select new
                        {
                            requestId = r.Document_Request_ID,

                            documentType = t.Document_Name,

                            purpose = p.Purpose_Description,

                            status = pg.Progress_Description,

                            residentName = res != null
                                ? res.Contact_Number
                                : "Unknown",

                            dateRequested = r.Created_At,

                            priority =

                                // HIGHEST PRIORITY
                                t.Document_Name == "Certification for Legal Purposes"
                                    ? "Highest Priority"

                                // HIGH PRIORITY
                                : t.Document_Name == "First Time Job Seeker Certificate" ||
                                  t.Document_Name == "Barangay Clearance" ||
                                  t.Document_Name == "Barangay Clearance for Business Permit" ||
                                   t.Document_Name == "Certificate of Indigency"
                                    ? "High Priority"

                                // MEDIUM PRIORITY
                                : t.Document_Name == "Certificate of Residency" ||
                                  t.Document_Name == "Certificate of Cohabitation" ||
                                  t.Document_Name == "Certificate of Good Moral Character" ||
                                  t.Document_Name == "Certificate of No Pending Case"
                                    ? "Medium Priority"

                                // LOW PRIORITY
                                : "Low Priority"
                        }
                    )
                    .Take(3)
                    .ToList();

                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                errorHandlerClass.errorHandler(
                    ex.StackTrace,
                    ex.InnerException?.ToString(),
                    ex.Message
                );

                return Json(new List<object>(), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetManageRequests()
        {
            try
            {
                using (var db = new IKONNEKTA51Context())
                {
                    var data = (
                        from r in db.tbl_Document_Requests

                        join res in db.tbl_Residents
                            on r.Resident_ID equals res.Resident_ID into resGroup
                        from res in resGroup.DefaultIfEmpty()

                        join details in db.tbl_Resident_Details
                            on res.Resident_Details_ID equals details.Resident_Details_ID into detGroup
                        from details in detGroup.DefaultIfEmpty()

                        join fullname in db.tbl_Resident_Fullname
                            on details.Resident_FullName_ID equals fullname.Resident_FullName_ID into nameGroup
                        from fullname in nameGroup.DefaultIfEmpty()

                        join t in db.tbl_Document_Types
                            on r.Document_Type_ID equals t.Document_Type_ID into tGroup
                        from t in tGroup.DefaultIfEmpty()

                        join p in db.tbl_Request_Purposes
                            on r.Purpose_ID equals p.Purpose_ID into pGroup
                        from p in pGroup.DefaultIfEmpty()

                        join s in db.tbl_Document_Request_Status
                            on r.Request_Status_ID equals s.Request_Status_ID into sGroup
                        from s in sGroup.DefaultIfEmpty()

                        join pg in db.tbl_request_progress
                            on s.Progress_ID equals pg.Progress_ID into pgGroup
                        from pg in pgGroup.DefaultIfEmpty()

                        where r.Resident_ID > 0

                        orderby

                            // ===== PRIORITY SORTING (HIGHEST TO LOWEST) =====
                            (
                                t.Document_Name == "Certification for Legal Purposes" ? 1 :

                                t.Document_Name == "Barangay Clearance for Business Permit" ? 2 :
                                t.Document_Name == "Barangay Clearance" ? 2 :
                                t.Document_Name == "First Time Job Seeker Certificate" ? 2 :
                                t.Document_Name == "Certificate of Indigency" ? 2 :

                                t.Document_Name == "Certificate of Residency" ? 3 :
                                t.Document_Name == "Certificate of Cohabitation" ? 3 :
                                t.Document_Name == "Certificate of Good Moral Character" ? 3 :
                                t.Document_Name == "Certificate of No Pending Case" ? 3 :

                                t.Document_Name == "Barangay ID" ? 4 :
                                t.Document_Name == "Barangay Certificate" ? 4 :
                                t.Document_Name == "Certificate of Non-Residency" ? 4 : 5
                            ),
                            r.Created_At ascending

                        select new
                        {
                            requestId = r.Document_Request_ID,

                            residentName =
                                (fullname.First_Name ?? "") + " " +
                                (fullname.Middle_Name ?? "") + " " +
                                (fullname.Last_Name ?? ""),

                            mobileNumber = res.Contact_Number,

                            documentType = t.Document_Name,

                            purpose = p.Purpose_Description,

                            status = pg.Progress_Description,

                            dateRequested = r.Created_At,

                            // ===== DISPLAY PRIORITY =====
                            priority =
                                (t.Document_Name == "Certification for Legal Purposes")
                                    ? "Highest Priority"

                                : (t.Document_Name == "Barangay Clearance for Business Permit" ||
                                   t.Document_Name == "Barangay Clearance" ||
                                   t.Document_Name == "Certificate of Indigency" || 
                                   t.Document_Name == "First Time Job Seeker Certificate")
                                    ? "High Priority"

                                : (t.Document_Name == "Certificate of Residency" ||
                                   t.Document_Name == "Certificate of Cohabitation" ||
                                   t.Document_Name == "Certificate of Good Moral Character" ||
                                   t.Document_Name == "Certificate of No Pending Case")
                                    ? "Medium Priority"

                                : (t.Document_Name == "Barangay ID" ||
                                   t.Document_Name == "Certificate of Non-Residency" ||
                                   t.Document_Name == "Barangay Certificate")
                                    ? "Low Priority"

                                : "Low Priority"
                        }
                    ).ToList();

                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                errorHandlerClass.errorHandler(
                    ex.StackTrace,
                    ex.InnerException?.ToString(),
                    ex.Message
                );

                return Json(new List<object>(), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetRequestDetails(int requestId)
        {
            try
            {
                using (var db = new IKONNEKTA51Context())
                {
                    var data = (
                        from r in db.tbl_Document_Requests

                        join res in db.tbl_Residents
                            on r.Resident_ID equals res.Resident_ID into resGroup
                        from res in resGroup.DefaultIfEmpty()

                        join details in db.tbl_Resident_Details
                            on res.Resident_Details_ID equals details.Resident_Details_ID into detGroup
                        from details in detGroup.DefaultIfEmpty()

                        join fullname in db.tbl_Resident_Fullname
                            on details.Resident_FullName_ID equals fullname.Resident_FullName_ID into nameGroup
                        from fullname in nameGroup.DefaultIfEmpty()

                        join t in db.tbl_Document_Types
                            on r.Document_Type_ID equals t.Document_Type_ID into tGroup
                        from t in tGroup.DefaultIfEmpty()

                        join p in db.tbl_Request_Purposes
                            on r.Purpose_ID equals p.Purpose_ID into pGroup
                        from p in pGroup.DefaultIfEmpty()

                        join s in db.tbl_Document_Request_Status
                            on r.Request_Status_ID equals s.Request_Status_ID into sGroup
                        from s in sGroup.DefaultIfEmpty()

                        join pg in db.tbl_request_progress
                            on s.Progress_ID equals pg.Progress_ID into pgGroup
                        from pg in pgGroup.DefaultIfEmpty()

                        where r.Document_Request_ID == requestId

                        select new
                        {
                            requestId = r.Document_Request_ID,

                            fullName =
                                (fullname.First_Name ?? "") + " " +
                                (fullname.Middle_Name ?? "") + " " +
                                (fullname.Last_Name ?? ""),

                            contactNumber = res.Contact_Number,

                            address = res.Address,

                            documentType = t.Document_Name,
                            purpose = p.Purpose_Description,

                            status = pg.Progress_Description,

                            dateRequested = r.Created_At
                        }
                    ).FirstOrDefault();

                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

    }
}