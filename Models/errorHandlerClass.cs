using iKonnekta_51.Models.Context;
using iKonnekta_51.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models
{
    public static class errorHandlerClass
    {
        public static void errorHandler(string stackTrace, string innerException, string message)
        {
            using(var db = new IKONNEKTA51Context())
            {
                var errorLog = new tbl_error_logs_model()
                {
                    Error_Description = $"{stackTrace} | {innerException} | {message}",
                    Created_At = DateTime.Now,
                    Edited_At = DateTime.Now
                };
                db.tbl_Error_Logs.Add(errorLog);
                db.SaveChanges();
            }
        }
    }
}