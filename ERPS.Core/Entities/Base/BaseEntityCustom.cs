using ERPS.Core.Entities.Base.Interface;
using System.ComponentModel.DataAnnotations;

namespace ERPS.Core.Entities.Base
{
    public class BaseEntityCustom : IBaseEntityStandard
    {
		[MaxLength(100)]
		public string LogBy { get; set; } = string.Empty;
		[MaxLength(500)]
		public string LogByUserDisplayName { get; set; } = string.Empty;
        public DateTime LogDate { get; set; } = DateTime.Now;
        private DateTime _LogDateUTC;
        public DateTime LogDateUTC
        {
            get
            {
                return _LogDateUTC;
            }
            set
            {
                if (value.Kind == DateTimeKind.Unspecified)
                {
                    _LogDateUTC = DateTime.SpecifyKind(value, DateTimeKind.Utc);
                }
                else
                {
                    _LogDateUTC = value;
                }
            }
        }
        public int LogInc { get; set; }
		[MaxLength(100)]
		public string CreatedBy { get; set; } = string.Empty;
		[MaxLength(500)]
		public string CreatedByUserDisplayName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        private DateTime _CreatedDateUTC;
        public DateTime CreatedDateUTC
        {
            get
            {
                return _CreatedDateUTC;
            }
            set
            {
                if (value.Kind == DateTimeKind.Unspecified)
                {
                    _CreatedDateUTC = DateTime.SpecifyKind(value, DateTimeKind.Utc);
                }
                else
                {
                    _CreatedDateUTC = value;
                }
            }
        }
		[MaxLength(5000)]
		public string Remarks { get; set; } = string.Empty;
        public bool Disabled { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
		
        // [Column(TypeName = "decimal(18, 8)")]
    }
}
