﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace API_HRIS.Models;

public partial class TblNotification
{
    public int Id { get; set; }
    public string? Notification { get; set; }
    public int? UserId { get; set; }
    public int? StatusId { get; set; }
    public DateTime? Date { get; set; }
}