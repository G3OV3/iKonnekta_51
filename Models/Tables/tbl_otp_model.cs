using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Tables
{
    public class tbl_otp_model
    {
        public int OTP_ID { get; set; }
        public int User_ID { get; set; }
        public string OTP_Code { get; set; }
        public int OTP_Type_ID { get; set; }
        public string Receiver { get; set; }

        public int OTP_Status_ID { get; set; }

        public DateTime Expiration_Time { get; set; }
        public DateTime Created_At { get; set; }
    }
}