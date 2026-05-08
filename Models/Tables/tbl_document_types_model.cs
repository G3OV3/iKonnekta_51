using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Tables
{
    public class tbl_document_types_model
    {
        public int Document_Type_ID { get; set; }

        public string Document_Name { get; set; }

        public decimal Baseline_Hours { get; set; }

        public int Default_Priority_Level_ID { get; set; }

        public bool Is_Active { get; set; }

        public DateTime Created_At { get; set; }
    }
}