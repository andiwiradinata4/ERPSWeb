using System.ComponentModel.DataAnnotations.Schema;

namespace ERPS.Core.Entities
{
    [Table("mstToken")]
    public class Token
    {
        public string? ID { get; set; }
        public string UserID { get; set; } = string.Empty;
        public string TokenType { get; set; } = string.Empty;
        public string TokenValue { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
