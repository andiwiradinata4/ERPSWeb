using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPS.Core.Entities.Transaction
{
    [Table("traReceiveStatus")]
    public class ReceiveStatus
    {
        [ForeignKey("Receive")]
        [MaxLength(100)]
        public string ReceiveId { get; set; } = string.Empty;
        public Receive? Receive { get; set; }
        [MaxLength(100)]
        public string StatusById { get; set; } = string.Empty;
        [MaxLength(100)]
        public string StatusByUserDisplayName { get; set; } = string.Empty;
        public DateTime StatusDate { get; set; } = DateTime.Now;
        private DateTime _StatusDateUTC;
        public DateTime StatusDateUTC
        {
            get
            {
                return _StatusDateUTC;
            }
            set
            {
                if (value.Kind == DateTimeKind.Unspecified)
                {
                    _StatusDateUTC = DateTime.SpecifyKind(value, DateTimeKind.Utc);
                }
                else
                {
                    _StatusDateUTC = value;
                }
            }
        }
    }
}
