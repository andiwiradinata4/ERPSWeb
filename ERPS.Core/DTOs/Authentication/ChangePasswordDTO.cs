﻿using System.ComponentModel.DataAnnotations;

namespace ERPS.Core.DTOs.Authentication
{
    public class ChangePasswordDTO
    {
        [Required]
        public string CurrentPassword { get; set; } = string.Empty;
        [Required]
        public string NewPassword { get; set; } = string.Empty;
    }
}
