﻿using System.ComponentModel.DataAnnotations;

namespace ERPS.Core.DTOs.Authentication
{
    public class RegisterDTO
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
