using System.ComponentModel.DataAnnotations.Schema;

namespace ERPS.Core.Models
{
    [Table("mstGender")]
    public class Gender : Base
    {
        public int ID { get; set; }
        public string Description { get; set; } = String.Empty;
        [ForeignKey("Status")]
        public int StatusID { get; set; }
        public Status Status { get; set; } = new Status();
        public List<Driver> Drivers { get; set; } = new List<Driver>();
    }
}