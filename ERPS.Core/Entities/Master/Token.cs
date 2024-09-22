using ERPS.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPS.Core.Entities.Master
{
    [Table("mstToken")]
    public class Token : BaseEntity
    {
        [MaxLength(100)]
        public string UserID { get; set; } = string.Empty;
        [MaxLength(100)]
        public string TokenType { get; set; } = string.Empty;
        [MaxLength(5000)]
        public string TokenValue { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Code { get; set; } = string.Empty;
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
