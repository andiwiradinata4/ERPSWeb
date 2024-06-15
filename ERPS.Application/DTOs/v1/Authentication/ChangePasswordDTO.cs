using System.ComponentModel.DataAnnotations;
namespace ERPS.Application.DTOs.v1.Authentication
{
    public class ChangePasswordDTO
    {
        [Required]
        public string CurrentPassword { get; set; } = string.Empty;
        [Required]
        public string NewPassword { get; set; } = string.Empty;
    }
}
