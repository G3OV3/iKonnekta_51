using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Tables
{
    public class tbl_resident_details_model
    {
        public int Resident_Details_ID { get; set; }
        public int Resident_FullName_ID { get; set; }
        public int Resident_Birth_ID { get; set; }
        public int Gender_ID { get; set; }
        public int Civil_Status_ID { get; set; }
        public int Religion_ID { get; set; }
        public int Citizenship_ID { get; set; }
        public int Occupation_ID { get; set; }
        public int Educational_Attainment_ID { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Edited_At { get; set; }
    }
}