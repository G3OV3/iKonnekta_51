using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Tables
{
    public class tbl_document_requests_model
    {
        public int Document_Request_ID { get; set; }

        public int Resident_ID { get; set; }

        public int Document_Type_ID { get; set; }

        public int Purpose_ID { get; set; }

        public int Quantity { get; set; }

        public int Priority_Level_ID { get; set; }

        public int Request_Status_ID { get; set; }

        public DateTime Created_At { get; set; }

        public DateTime Edited_At { get; set; }
    }
}