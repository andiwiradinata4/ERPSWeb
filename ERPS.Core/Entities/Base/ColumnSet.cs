using System.ComponentModel.DataAnnotations;

namespace NetCore.Models
{
    public class ColumnSet
    {
        [MaxLength(500)]
        public string? Name { get; set; }
        [MaxLength(100)]
        public string? Type { get; set; }
        public int? Size { get; set; }
    }
}
