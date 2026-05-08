using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Tables
{
    public class tbl_user_model
    {
        public int User_ID { get; set; }

        public int Resident_ID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int Role_ID { get; set; }

        public int Account_Status_ID { get; set; }

        public DateTime? Last_Login { get; set; }

        public DateTime Created_At { get; set; }

        public DateTime Updated_At { get; set; }
    }
}