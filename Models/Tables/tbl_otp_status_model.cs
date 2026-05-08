using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Tables
{
    public class tbl_otp_status_model
    {
        public int OTP_Status_ID { get; set; }
        public string OTP_Status_Description { get; set; }

        public DateTime Created_At { get; set; }
        public DateTime Edited_At { get; set; }
    }
}