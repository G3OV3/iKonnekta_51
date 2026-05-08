using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using iKonnekta_51.Models.Tables;
using iKonnekta_51.Models.Maps;

namespace iKonnekta_51.Models.Context
{
    public class IKONNEKTA51Context : DbContext
    {
        static IKONNEKTA51Context()
        {
            Database.SetInitializer<IKONNEKTA51Context>(null);
        }

        public IKONNEKTA51Context() : base("Name=IKONNEKTA51Db") { }

        public virtual DbSet<tbl_resident_model> tbl_Residents { get; set; }
        public virtual DbSet<tbl_resident_details_model> tbl_Resident_Details { get; set; }
        public virtual DbSet<tbl_resident_fullname_model> tbl_Resident_Fullname { get; set; }
        public virtual DbSet<tbl_resident_birth_details_model> tbl_Resident_Birth_Details { get; set; }
        public virtual DbSet<tbl_resident_status_model> tbl_Resident_Status { get; set; }
        public virtual DbSet<tbl_resident_gender_model> tbl_Resident_Gender { get; set; }
        public virtual DbSet<tbl_resident_civil_status_model> tbl_Resident_Civil_Status { get; set; }
        public virtual DbSet<tbl_resident_citizenships_model> tbl_Resident_Citizenships { get; set; }
        public virtual DbSet<tbl_resident_religion_model> tbl_Resident_Religion { get; set; }
        public virtual DbSet<tbl_resident_occupation_model> tbl_Resident_Occupation { get; set; }
        public virtual DbSet<tbl_resident_educational_attainment_model> tbl_Resident_Educational_Attainment { get; set; }

        public virtual DbSet<tbl_user_model> tbl_Users { get; set; }
        public virtual DbSet<tbl_user_roles_model> tbl_User_Roles { get; set; }
        public virtual DbSet<tbl_user_account_status_model> tbl_User_Account_Status { get; set; }

        public virtual DbSet<tbl_otp_model> tbl_OTP { get; set; }
        public virtual DbSet<tbl_otp_types_model> tbl_OTP_Types { get; set; }
        public virtual DbSet<tbl_otp_status_model> tbl_OTP_Status { get; set; }

        public virtual DbSet<tbl_document_types_model> tbl_Document_Types { get; set; }
        public virtual DbSet<tbl_request_purposes_model> tbl_Request_Purposes { get; set; }

        public virtual DbSet<tbl_document_requests_model> tbl_Document_Requests { get; set; }
        public virtual DbSet<tbl_document_request_status_model> tbl_Document_Request_Status { get; set; }

        public virtual DbSet<tbl_notification_model> tbl_Notifications { get; set; }
        public virtual DbSet<tbl_document_templates_model> tbl_Document_Templates { get; set; }
        public virtual DbSet<tbl_ai_forecasts_model> tbl_AI_Forecasts { get; set; }
        public virtual DbSet<tbl_system_logs_model> tbl_System_Logs { get; set; }
        public virtual DbSet<tbl_error_logs_model> tbl_Error_Logs { get; set; }
        public virtual DbSet<tbl_priority_levels_model> tbl_Priority_Levels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new tbl_Residents_Map());
            modelBuilder.Configurations.Add(new tbl_Resident_Details_Map());
            modelBuilder.Configurations.Add(new tbl_Resident_Fullname_Map());
            modelBuilder.Configurations.Add(new tbl_Resident_Birth_Details_Map());
            modelBuilder.Configurations.Add(new tbl_Resident_Status_Map());
            modelBuilder.Configurations.Add(new tbl_Resident_Gender_Map());
            modelBuilder.Configurations.Add(new tbl_Resident_Civil_Status_Map());
            modelBuilder.Configurations.Add(new tbl_Resident_Citizenships_Map());
            modelBuilder.Configurations.Add(new tbl_Resident_Religion_Map());
            modelBuilder.Configurations.Add(new tbl_Resident_Occupation_Map());
            modelBuilder.Configurations.Add(new tbl_Resident_Educational_Attainment_Map());

            modelBuilder.Configurations.Add(new tbl_Users_Map());
            modelBuilder.Configurations.Add(new tbl_User_Roles_Map());
            modelBuilder.Configurations.Add(new tbl_User_Account_Status_Map());

            modelBuilder.Configurations.Add(new tbl_OTP_Map());
            modelBuilder.Configurations.Add(new tbl_OTP_Types_Map());
            modelBuilder.Configurations.Add(new tbl_OTP_Status_Map());

            modelBuilder.Configurations.Add(new tbl_Document_Types_Map());
            modelBuilder.Configurations.Add(new tbl_Request_Purposes_Map());

            modelBuilder.Configurations.Add(new tbl_Document_Requests_Map());
            modelBuilder.Configurations.Add(new tbl_Document_Request_Status_Map());

            modelBuilder.Configurations.Add(new tbl_Notifications_Map());
            modelBuilder.Configurations.Add(new tbl_Document_Templates_Map());
            modelBuilder.Configurations.Add(new tbl_AI_Forecasts_Map());
            modelBuilder.Configurations.Add(new tbl_System_Logs_Map());
            modelBuilder.Configurations.Add(new tbl_Error_Logs_Map());
            modelBuilder.Configurations.Add(new tbl_Priority_Levels_Map());
        }
    }
}