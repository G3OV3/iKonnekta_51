using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Tables
{
    public class tbl_resident_citizenships_model
    {
        public int Citizenship_ID { get; set; }
        public string Citizenship_Description { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Edited_At { get; set; }
    }
}