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
        public JsonResult registerUser(tbl_user_model userInfo)
        {
            try
            {
                using(var db = new IKONNEKTA51Context())
                {
                    var userData = new tbl_user_model()
                    {
                        
                        Username = userInfo.Username,
                        Password = userInfo.Password,
                        Role_ID = 1,
                        Account_Status_ID = 1,
                        Last_Login = DateTime.Now,
                        Created_At = DateTime.Now,
                        Updated_At = DateTime.Now
                    };
                    db.tbl_Users.Add(userData);
                    db.SaveChanges();
                    return Json(new { sucess = true });
                }
            }
            catch(Exception ex)
            {
                errorHandlerClass.errorHandler(ex.StackTrace, ex.InnerException.ToString(), ex.Message);
                return Json(new { success = false });
            }
        }
    }
}