using System.ComponentModel.DataAnnotations;

namespace ERPS.Application.DTOs.v1.Authentication
{
    public class ChangeEmailTokenDTO
    {
        [Required]
        [EmailAddress]
        public string NewEmail { get; set; } = string.Empty;
    }
}
