namespace ERPS.Core.Entities
{
    public class Base
    {
        public string LogBy { get; set; } = "SYSTEM";
        public DateTime LogDate { get; set; } = DateTime.Now;
        public int LogInc { get; set; }
        public string CreatedBy { get; set; } = "SYSTEM";
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Remarks { get; set; } = string.Empty;
    }
}