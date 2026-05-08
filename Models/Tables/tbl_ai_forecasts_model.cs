using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Tables
{
    public class tbl_ai_forecasts_model
    {
        public int Forecast_ID { get; set; }
        public int Request_ID { get; set; }
        public decimal Predicted_Hours { get; set; }
        public decimal Actual_Hours { get; set; }
        public decimal Prediction_Accuracy { get; set; }
        public DateTime Generated_At { get; set; }
    }
}