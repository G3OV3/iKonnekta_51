using iKonnekta_51.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Maps
{
    public class tbl_Users_Map : EntityTypeConfiguration<tbl_user_model>
    {
        public tbl_Users_Map()
        {
            HasKey(i => i.User_ID);
            ToTable("tbl_user");
        }
    }
}