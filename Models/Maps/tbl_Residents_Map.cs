using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using iKonnekta_51.Models.Tables;

namespace iKonnekta_51.Models.Maps
{
    public class tbl_Residents_Map : EntityTypeConfiguration<tbl_resident_model>
    {
        public tbl_Residents_Map()
        {
            HasKey(i => i.Resident_ID);
            ToTable("tbl_resident");
        }
    }
}