using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Tables
{
    public class tbl_priority_levels_model
    {
        public int Priority_Level_ID { get; set; }

        public string Priority_Level_Description { get; set; }

        public int Priority_Score { get; set; }

        public DateTime Created_At { get; set; }

        public DateTime Edited_At { get; set; }
    }
}