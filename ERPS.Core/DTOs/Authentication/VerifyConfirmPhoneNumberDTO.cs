using System.ComponentModel.DataAnnotations;

namespace ERPS.Core.DTOs.Authentication
{
    public class VerifyConfirmPhoneNumberDTO
    {
        [Required]
        public string Token { get; set; } = string.Empty;
        [Required]
        public string Code { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
