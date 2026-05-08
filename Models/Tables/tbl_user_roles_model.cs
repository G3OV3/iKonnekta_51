using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Tables
{
    public class tbl_user_roles_model
    {
        public int Role_ID { get; set; }
        public string Role_Description { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
    }
}