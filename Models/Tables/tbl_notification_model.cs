using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Tables
{
    public class tbl_notification_model
    {
        public int Notification_ID { get; set; }
        public int User_ID { get; set; }
        public string Notification_Title { get; set; }
        public string Notification_Message { get; set; }
        public string Notification_Type { get; set; }
        public bool Is_Read { get; set; }
        public DateTime Created_At { get; set; }
    }
}