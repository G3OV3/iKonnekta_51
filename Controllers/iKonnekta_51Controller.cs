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
        // iKonnekta_51Controller.cs

        public JsonResult loginUser(tbl_user_model userLoginInfo)
        {
            try
            {
                using (var db = new IKONNEKTA51Context())
                {
                    var userData = (from u in db.tbl_Users

                                    join r in db.tbl_Residents
                                    on u.Resident_ID equals r.Resident_ID

                                    join rd in db.tbl_Resident_Details
                                    on r.Resident_Details_ID equals rd.Resident_Details_ID

                                    join rf in db.tbl_Resident_Fullname
                                    on rd.Resident_FullName_ID equals rf.Resident_FullName_ID

                                    join rb in db.tbl_Resident_Birth_Details
                                    on rd.Resident_Birth_ID equals rb.Resident_Birth_ID

                                    where u.Username == userLoginInfo.Username

                                    select new
                                    {
                                        User = u,
                                        Resident = r,
                                        Fullname = rf,
                                        Birth = rb
                                    })
                                    .FirstOrDefault();

                    if (userData == null)
                    {
                        return Json(new
                        {
                            success = false,
                            message = "User not found"
                        });
                    }

                    if (userData.User.Account_Status_ID != 1)
                    {
                        return Json(new
                        {
                            success = false,
                            message = "Account is inactive"
                        });
                    }

                    bool isPasswordValid = BCrypt.Net.BCrypt.Verify(
                        userLoginInfo.Password,
                        userData.User.Password
                    );

                    if (!isPasswordValid)
                    {
                        return Json(new
                        {
                            success = false,
                            message = "Invalid password"
                        });
                    }

                    userData.User.Last_Login = DateTime.Now;

                    db.tbl_System_Logs.Add(new tbl_system_logs_model
                    {
                        User_ID = userData.User.User_ID,
                        Logged_In_At = DateTime.Now,
                        Logged_Out_At = null
                    });

                    db.SaveChanges();

                    return Json(new
                    {
                        success = true,

                        roleId = userData.User.Role_ID,
                        userId = userData.User.User_ID,
                        residentId = userData.Resident.Resident_ID,
                        username = userData.User.Username,

                        firstName = userData.Fullname.First_Name,
                        lastName = userData.Fullname.Last_Name,

                        contact = userData.Resident.Contact_Number,

                        address = userData.Birth.Birth_Place
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
                        Role_ID = 2,
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