﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MVC_HRIS.Models;

public partial class TblTimeLog
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateTime? Date { get; set; }

    public int? TaskId { get; set; }
    public string? Remarks { get; set; }

    public string? TimeIn { get; set; }

    public string? TimeOut { get; set; }

    public decimal? RenderedHours { get; set; }
    public int? StatusId { get; set; }
    public int? DeleteFlag { get; set; }
    public string Identifier { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
    public DateTime? DateDeleted { get; set; }

}