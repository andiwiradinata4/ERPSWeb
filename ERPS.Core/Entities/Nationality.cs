using System.ComponentModel.DataAnnotations.Schema;
using ERPS.Core.Entities.Base;

namespace ERPS.Core.Entities
{
    [Table("mstNationality")]
    public class Nationality: BaseEntity
    {
        public int ID { get; set; }
        public string Description { get; set; } = String.Empty;
        [ForeignKey("Status")]
        public int StatusID { get; set; }
        public Status Status { get; set; } = new Status();
        public List<Driver> Drivers { get; set; } = new List<Driver>();
    }
}
