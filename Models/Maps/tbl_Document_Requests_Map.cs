using iKonnekta_51.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace iKonnekta_51.Models.Maps
{
    public class tbl_Document_Requests_Map : EntityTypeConfiguration<tbl_document_requests_model>
    {
        public tbl_Document_Requests_Map()
        {
            HasKey(i => i.Document_Request_ID);
            ToTable("tbl_document_requests");
        }
    }
}