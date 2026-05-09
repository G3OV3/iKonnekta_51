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


    }
}