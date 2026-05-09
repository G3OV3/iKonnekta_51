using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Tables
{
    public class tbl_document_request_status_model
    {
        public int Request_Status_ID { get; set; }

        public int Progress_ID { get; set; } // MUST match SQL

        public decimal Estimation_Completion_Time { get; set; }

        public int Queue_Position { get; set; }

        public DateTime Requested_At { get; set; }

        public DateTime? Processed_At { get; set; }
        public DateTime? Completed_At { get; set; }
        public DateTime? Released_At { get; set; }
        public DateTime? Cancelled_At { get; set; }
    }
}