using iKonnekta_51.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Maps
{
    public class tbl_Resident_Citizenships_Map : EntityTypeConfiguration<tbl_resident_citizenships_model>
    {
        public tbl_Resident_Citizenships_Map()
        {
            HasKey(i => i.Citizenship_ID);
            ToTable("tbl_resident_citizenships");
        }
    }
}