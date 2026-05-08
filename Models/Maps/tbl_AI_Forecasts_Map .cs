using iKonnekta_51.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Maps
{
    public class tbl_AI_Forecasts_Map : EntityTypeConfiguration<tbl_ai_forecasts_model>
    {
        public tbl_AI_Forecasts_Map()
        {
            HasKey(i => i.Forecast_ID);
            ToTable("tbl_ai_forecasts");
        }
    }
}