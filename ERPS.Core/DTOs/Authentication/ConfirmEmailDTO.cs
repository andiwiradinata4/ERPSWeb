using System.ComponentModel.DataAnnotations;

namespace ERPS.Core.DTOs.Authentication
{
    public class ConfirmEmailDTO
    {
        [Required]
        public string Code { get; set; } = string.Empty;
    }
}
