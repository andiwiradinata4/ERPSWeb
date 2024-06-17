using System.ComponentModel.DataAnnotations;

namespace ERPS.Application.DTOs.v1.Authentication
{
    public class VerifyTokenDTO
    {
        [Required]
        public string Token { get; set; } = string.Empty;
        [Required]
        public string Code { get; set; } = string.Empty;
    }
}
