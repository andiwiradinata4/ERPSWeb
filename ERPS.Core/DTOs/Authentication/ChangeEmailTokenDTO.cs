using System.ComponentModel.DataAnnotations;

namespace ERPS.Core.DTOs.Authentication
{
    public class ChangeEmailTokenDTO
    {
        [Required]
        [EmailAddress]
        public string NewEmail { get; set; } = string.Empty;
    }
}
