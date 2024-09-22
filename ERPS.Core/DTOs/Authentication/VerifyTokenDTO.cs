﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPS.Core.DTOs.Authentication
{
    public class VerifyTokenDTO
    {
        [Required]
        public string AccessToken { get; set; } = string.Empty;
        [Required]
        public string Code { get; set; } = string.Empty;
    }
}
