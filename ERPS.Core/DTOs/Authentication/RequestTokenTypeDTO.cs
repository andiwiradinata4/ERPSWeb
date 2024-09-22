using System.ComponentModel.DataAnnotations;

namespace ERPS.Core.DTOs.Authentication
{
    public class RequestTokenTypeDTO
    {
        [Required]
        public string TokenType { get; set; } = string.Empty;
    }
}
