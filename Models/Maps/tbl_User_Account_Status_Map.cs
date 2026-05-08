using iKonnekta_51.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Maps
{
    public class tbl_User_Account_Status_Map : EntityTypeConfiguration<tbl_user_account_status_model>
    {
        public tbl_User_Account_Status_Map()
        {
            HasKey(i => i.Account_Status_ID);
            ToTable("tbl_user_account_status");
        }
    }
}