﻿using System.ComponentModel.DataAnnotations;

namespace ERPS.Core.Entities.Base.Interface
{
    public interface IBaseEntityStandard
    {
        string LogBy { get; set; }
        string LogByUserDisplayName { get; set; }
        DateTime LogDate { get; set; }
        DateTime LogDateUTC { get; set; }
        int LogInc { get; set; }
        string CreatedBy { get; set; }
        string CreatedByUserDisplayName { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime CreatedDateUTC { get; set; }
        string Remarks { get; set; }
        bool Disabled { get; set; }
        [Timestamp]
        byte[] RowVersion { get; set; }
    }
}