using System.ComponentModel.DataAnnotations;

namespace ERPS.Application.DTOs.v1.Authentication
{
    public class ChangePhoneNumberDTO
    {
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string NewPhoneNumber { get; set; } = string.Empty;
        [Required]
        public string Token { get; set; } = string.Empty;
        [Required]
        public string Code { get; set; } = string.Empty;
    }
}
