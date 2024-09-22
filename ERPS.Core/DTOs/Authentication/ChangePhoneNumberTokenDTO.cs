using System.ComponentModel.DataAnnotations;

namespace ERPS.Core.DTOs.Authentication
{
    public class ChangePhoneNumberTokenDTO
    {
        [Required]
        public string NewPhoneNumber { get; set; } = string.Empty;
    }
}
