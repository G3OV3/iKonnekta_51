using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Tables
{
    public class tbl_system_logs_model
    {
        public int Log_ID { get; set; }
        public int User_ID { get; set; }
        public DateTime Logged_In_At { get; set; }
        public DateTime Logged_Out_At { get; set; }
    }
}