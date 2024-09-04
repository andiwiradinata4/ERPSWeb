using System.ComponentModel.DataAnnotations;

namespace ERPS.Core.Entities
{
    public class BaseEntity
    {
        public string LogBy { get; set; } = "SYSTEM";
        public DateTime LogDate { get; set; } = DateTime.Now;
        public DateTime LogDateUtc { get; set; } = DateTime.Now.ToUniversalTime();
        public int LogInc { get; set; }
        public string CreatedBy { get; set; } = "SYSTEM";
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime CreatedDateUtc { get; set; } = DateTime.Now.ToUniversalTime();
        public string Remarks { get; set; } = string.Empty;
        public bool IsDisabled { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}