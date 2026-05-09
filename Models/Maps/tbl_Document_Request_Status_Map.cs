using iKonnekta_51.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Maps
{
    public class tbl_Document_Request_Status_Map: EntityTypeConfiguration<tbl_document_request_status_model>
    {
        public tbl_Document_Request_Status_Map()
        {
            HasKey(x => x.Request_Status_ID);
            ToTable("tbl_document_request_status");
        }
    }
}