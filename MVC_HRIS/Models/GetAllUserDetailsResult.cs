﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_HRIS.Models
{
    public partial class GetAllUserDetailsResult
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Suffix { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Mname { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string EmployeeID { get; set; }
        public string JWToken { get; set; }
        public string FilePath { get; set; }
        public int? ActiveStatusId { get; set; }
        public string Cno { get; set; }
        public string Address { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public DateTime Date_Created { get; set; }
        public DateTime? Date_Updated { get; set; }
        public bool? Delete_Flag { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Date_Deleted { get; set; }
        public string Deleted_By { get; set; }
        public string Restored_By { get; set; }
        public DateTime? Date_Restored { get; set; }
        public int? Department { get; set; }
        public bool? AgreementStatus { get; set; }
        public string RememberToken { get; set; }
        public string SalaryType { get; set; }
        [Column("Rate", TypeName = "decimal(18,2)")]
        public decimal? Rate { get; set; }
        public string PayrollType { get; set; }
        public int UserTypeId { get; set; }
        public string UserType { get; set; }
        public DateTime? DateStarted { get; set; }
    }
}
