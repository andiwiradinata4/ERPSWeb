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
    [Table("mstItemType")]
    public class ItemType : BaseEntity
    {
        [MaxLength(100)]
        public string Code { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Name { get; set; } = string.Empty;
        public IEnumerable<Item> Items { get; set; } = [];
    }
}
