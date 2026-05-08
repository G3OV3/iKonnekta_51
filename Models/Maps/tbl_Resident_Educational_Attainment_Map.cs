using iKonnekta_51.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Maps
{
    public class tbl_Resident_Educational_Attainment_Map : EntityTypeConfiguration<tbl_resident_educational_attainment_model>
    {
        public tbl_Resident_Educational_Attainment_Map()
        {
            HasKey(i => i.Educational_Attainment_ID);
            ToTable("tbl_resident_educational_attainment");
        }
    }
}