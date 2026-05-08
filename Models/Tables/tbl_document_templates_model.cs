using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Tables
{
    public class tbl_document_templates_model
    {
        public int Template_ID { get; set; }
        public int Document_Type_ID { get; set; }
        public string Template_Name { get; set; }
        public string Template_Content { get; set; }
        public bool Is_Active { get; set; }
        public DateTime Created_At { get; set; }
    }
}