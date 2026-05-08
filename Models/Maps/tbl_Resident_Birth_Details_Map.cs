using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using iKonnekta_51.Models.Tables;

namespace iKonnekta_51.Models.Maps
{
    public class tbl_Resident_Birth_Details_Map : EntityTypeConfiguration<tbl_resident_birth_details_model>
    {
        public tbl_Resident_Birth_Details_Map()
        {
            HasKey(i => i.Resident_Birth_ID);
            ToTable("tbl_resident_birth_details");
        }
    }
}