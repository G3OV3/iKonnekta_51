using iKonnekta_51.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Maps
{
    public class tbl_Resident_Civil_Status_Map : EntityTypeConfiguration<tbl_resident_civil_status_model>
    {
        public tbl_Resident_Civil_Status_Map()
        {
            HasKey(i => i.Civil_Status_ID);
            ToTable("tbl_resident_civil_status");
        }
    }
}