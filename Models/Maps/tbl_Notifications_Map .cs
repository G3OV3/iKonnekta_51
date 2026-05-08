using iKonnekta_51.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Maps
{
    public class tbl_Notifications_Map : EntityTypeConfiguration<tbl_notification_model>
    {
        public tbl_Notifications_Map()
        {
            HasKey(i => i.Notification_ID);
            ToTable("tbl_notification");
        }
    }
}