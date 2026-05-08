using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Tables
{
    public class tbl_resident_educational_attainment_model
    {
        public int Educational_Attainment_ID { get; set; }
        public string Educational_Attainment_Description { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Edited_At { get; set; }
    }
}