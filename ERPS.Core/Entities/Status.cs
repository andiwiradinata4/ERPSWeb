using System.ComponentModel.DataAnnotations.Schema;

namespace ERPS.Core.Entities
{
    [Table("mstStatus")]
    public class Status : Base
    {
        public int ID { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public List<BloodType> BloodTypes { get; set; } = new List<BloodType>();
        public List<Gender> Genders { get; set; } = new List<Gender>();
        public List<MaritalStatus> MaritalStatus { get; set; } = new List<MaritalStatus>();
        public List<Nationality> Nationality { get; set; } = new List<Nationality>();
        public List<Religion> Religions { get; set; } = new List<Religion>();
        public List<Driver> Drivers { get; set; } = new List<Driver>();
    }
}