using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Tables
{
    public class tbl_resident_birth_details_model
    {
        public int Resident_Birth_ID { get; set; }
        public DateTime Birthdate { get; set; }
        public string Birth_Place { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Edited_At { get; set; }
    }
}