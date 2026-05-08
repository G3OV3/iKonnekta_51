using iKonnekta_51.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Maps
{
    public class tbl_Priority_Levels_Map : EntityTypeConfiguration<tbl_priority_levels_model>
    {
        public tbl_Priority_Levels_Map()
        {
            HasKey(i => i.Priority_Level_ID);

            ToTable("tbl_priority_levels");
        }
    }
}