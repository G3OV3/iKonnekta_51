using iKonnekta_51.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Maps
{
    public class tbl_Error_Logs_Map : EntityTypeConfiguration<tbl_error_logs_model>
    {
        public tbl_Error_Logs_Map()
        {
            HasKey(i => i.Error_ID);
            ToTable("tbl_error_logs");
        }
    }
}