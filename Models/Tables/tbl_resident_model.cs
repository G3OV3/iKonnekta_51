using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Tables
{
    public class tbl_resident_model
    {
        public int Resident_ID { get; set; }
        public string PhySys_Card_No { get; set; }
        public string Contact_Number { get; set; }
        public string Address { get; set; }
        public string Email_Address { get; set; }
        public DateTime Date_Registered { get; set; }
        public int Resident_Details_ID { get; set; }
        public int Resident_Status_ID { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Edited_At { get; set; }
    }
}