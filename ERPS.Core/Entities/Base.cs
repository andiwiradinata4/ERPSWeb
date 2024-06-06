namespace ERPS.Core.Models
{
    public class Base
    {
        public string LogBy { get; set; } = System.String.Empty;
        public DateTime LogDate { get; set; } = DateTime.Now;
        public int LogInc { get; set; }
        public string CreatedBy { get; set; } = System.String.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Remarks { get; set; } = string.Empty;
    }
}