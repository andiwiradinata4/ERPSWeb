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
    [Table("mstBusinessPartner")]
    public class BusinessPartner: BaseEntity
    {
        [MaxLength(500)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(1000)]
        public string Address { get; set; } = string.Empty;
        [MaxLength(100)]
        public string PIC { get; set; } = string.Empty;
        [MaxLength(100)]
        public string PhoneNumber { get; set; } = string.Empty;
        [MaxLength(100)]
        public string? NPWP { get; set; }
    }
}