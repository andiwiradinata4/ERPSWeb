using System.ComponentModel.DataAnnotations;

namespace ERPS.Core.DTOs.Authentication
{
    public class CheckTokenDTO
    {
        [Required]
        public string Token { get; set; } = String.Empty;
    }
}
