using System.ComponentModel.DataAnnotations;

namespace ERPS.Core.DTOs.Authentication
{
    public class PhoneNumberConfirmationTokenDTO
    {
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
