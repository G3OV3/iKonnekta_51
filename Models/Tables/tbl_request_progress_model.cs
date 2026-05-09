using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Tables
{
    public class tbl_request_progress_model
    {
        public int Progress_ID { get; set; }

        public string Progress_Description { get; set; }

        public DateTime Created_At { get; set; }

        public DateTime Edited_At { get; set; }
    }
}