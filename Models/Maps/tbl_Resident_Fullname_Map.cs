using iKonnekta_51.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Maps
{
    public class tbl_Resident_Fullname_Map : EntityTypeConfiguration<tbl_resident_fullname_model>
    {
        public tbl_Resident_Fullname_Map()
        {
            HasKey(i => i.Resident_FullName_ID);
            ToTable("tbl_resident_fullname");
        }
    }
}