using ERPS.Core.Entities.Base;
using ERPS.Core.Entities.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPS.Core.Entities.Transaction
{
    [Table("traReceive")]
    public class Receive : BaseEntity
    {
        [MaxLength(100)]
        public string ProgramId { get; set; } = string.Empty;
        public string CompanyId { get; set; } = string.Empty;
        [MaxLength(100)]
        public string DocumentNumber { get; set; } = string.Empty;
        [MaxLength(100)]
        public string ReferencesNumber { get; set; } = string.Empty;
        [MaxLength(100)]
        [ForeignKey("BusinessPartner")]
        public string BusinessPartnerId { get; set; } = string.Empty;
        public BusinessPartner? BusinessPartner { get; set; }
        [MaxLength(500)]
        public string DeliveryAddress { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal PPN { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PPH { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalQuantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalDPP { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPPN { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPPH { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalDiscount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalRoundingManual { get; set; }
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
        [MaxLength(100)]
        [ForeignKey("Status")]
        public string StatusId { get; set; } = string.Empty;
        public Status? Status { get; set; }
        [MaxLength(100)]
        public string SubmitById { get; set; } = string.Empty;
        [MaxLength(100)]
        public string SubmitByUserDisplayName { get; set; } = string.Empty;
        public IEnumerable<ReceiveDet> Details { get; set; } = [];
        public IEnumerable<ReceiveStatus> ReceiveStatus { get; set; } = [];
    }
}