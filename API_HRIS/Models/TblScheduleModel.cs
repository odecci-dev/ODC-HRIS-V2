﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace API_HRIS.Models;

public partial class TblScheduleModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? MondayS { get; set; }
    public string? MondayE { get; set; }
    public string? TuesdayS { get; set; }
    public string? TuesdayE { get; set; }
    public string? WednesdayS { get; set; }
    public string? WednesdayE { get; set; }
    public string? ThursdayS { get; set; }
    public string? ThursdayE { get; set; }
    public string? FridayS { get; set; }
    public string? FridayE { get; set; }
    public string? SaturdayS { get; set; }
    public string? SaturdayE { get; set; }
    public string? SundayS { get; set; }
    public string? SundayE { get; set; }
    public string? StatusID { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
    public DateTime? DateDeleted { get; set; }
}