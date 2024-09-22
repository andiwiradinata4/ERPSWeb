using ERPS.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPS.Core.Entities.Master
{
    [Table("mstItem")]
    public class Item: BaseEntity
    {
        [MaxLength(100)]
        public string CompanyId { get; set; } = string.Empty;
        public Company? Company { get; set; }
        [MaxLength(100)]
        public string Code { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(100)]
        [ForeignKey("Uom")]
        public string UomId { get; set; } = string.Empty;
        public Uom? Uom { get; set; }
        [MaxLength(100)]
        [ForeignKey("ItemType")]
        public string ItemTypeId { get; set; } = string.Empty;
        public ItemType? ItemType { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}