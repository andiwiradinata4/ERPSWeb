using System.ComponentModel.DataAnnotations;

namespace ERPS.Application.DTOs.v1.Authentication
{
    public class ResetPasswordTokenDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
