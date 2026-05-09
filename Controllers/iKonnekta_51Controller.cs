using iKonnekta_51.Models;
using iKonnekta_51.Models.Context;
using iKonnekta_51.Models.OtherClasses;
using iKonnekta_51.Models.Tables;
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
        public JsonResult registerUser(RegisterViewModel userInfo)
        {
            try
            {
                using (var db = new IKONNEKTA51Context())
                {
                    if (userInfo == null)
                    {
                        return Json(new { success = false, message = "Invalid request data." });
                    }

                    var pcn = userInfo.PhySys_Card_No.Trim();

                    var resident = db.tbl_Residents
                        .FirstOrDefault(r => r.PhySys_Card_No == pcn);

                    if (resident == null)
                    {
                        return Json(new
                        {
                            success = false,
                            message = "PhySys Card No not found in resident records."
                        });
                    }

                    var usernameExists = db.tbl_Users
                        .Any(i => i.Username == userInfo.Username);

                    if (usernameExists)
                    {
                        return Json(new { success = false, message = "Username already exists" });
                    }

                    var residentAlreadyRegistered = db.tbl_Users
                        .Any(i => i.Resident_ID == resident.Resident_ID);

                    if (residentAlreadyRegistered)
                    {
                        return Json(new { success = false, message = "Resident already has an account" });
                    }

                    var userData = new tbl_user_model()
                    {
                        Resident_ID = resident.Resident_ID,
                        Username = userInfo.Username,
                        Password = BCrypt.Net.BCrypt.HashPassword(userInfo.Password),
                        Role_ID = 1,
                        Account_Status_ID = 1,
                        Last_Login = null,
                        Created_At = DateTime.Now,
                        Updated_At = DateTime.Now
                    };

                    db.tbl_Users.Add(userData);
                    db.SaveChanges();

                    return Json(new { success = true });
                }
            } catch (Exception ex) 
            {
                errorHandlerClass.errorHandler(
                    ex.StackTrace,
                    ex.InnerException.ToString(),
                    ex.Message
                );

                return Json(new { success = false, message = "An error occurred" });
            }
        }
    }
}