using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPS.Core.Models
{
    [Table("mstBloodType")]
    public class BloodType : Base
    {
        public int ID { get; set; }
        [Required]
        public string Description { get; set; } = String.Empty;
        public int StatusID { get; set; }
        public Status? Status { get; set; }
        public List<Driver> Drivers { get; set; } = new List<Driver>();
    }
}