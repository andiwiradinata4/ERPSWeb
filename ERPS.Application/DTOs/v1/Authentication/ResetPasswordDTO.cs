using System.ComponentModel.DataAnnotations;

namespace NetCore.Models.dto.Account
{
    public class ResetPasswordDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string NewPassword { get; set; } = string.Empty;
        [Required]
        public string Token { get; set; } = string.Empty;
        [Required]
        public string Code { get; set; } = string.Empty;
    }
}
