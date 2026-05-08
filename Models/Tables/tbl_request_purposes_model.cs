using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Tables
{
    public class tbl_request_purposes_model
    {
        public int Purpose_ID { get; set; }
        public string Purpose_Description { get; set; }
        public DateTime Created_At { get; set; }
    }
}