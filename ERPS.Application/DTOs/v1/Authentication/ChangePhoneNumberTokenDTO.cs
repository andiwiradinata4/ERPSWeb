using System.ComponentModel.DataAnnotations;

namespace ERPS.Application.DTOs.v1.Authentication
{
    public class ChangePhoneNumberTokenDTO
    {
        [Required]
        public string NewPhoneNumber { get; set; } = string.Empty;
    }
}
