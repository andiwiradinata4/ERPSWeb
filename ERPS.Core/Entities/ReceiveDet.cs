using ERPS.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPS.Core.Entities
{
    [Table("traReceiveDet")]
    public class ReceiveDet:BaseEntity
    {
        [ForeignKey("Receive")]
        [MaxLength(100)]
        public string ReceiveId { get; set; } = String.Empty;
        public Receive? Receive { get; set; }
        [ForeignKey("Item")]
        [MaxLength(100)]
        public string ItemId { get; set; } = String.Empty;
        public Item? Item { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PercentageDiscount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal RoundingManual { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DPAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DPAmountPPN { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DPAmountPPH { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ReceiveAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ReceiveAmountPPN { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ReceiveAmountPPH { get; set; }
    }
}
