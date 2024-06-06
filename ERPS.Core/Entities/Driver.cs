using System.ComponentModel.DataAnnotations.Schema;

namespace ERPS.Core.Models
{
    [Table("mstDriver")]
    public class Driver : Base
    {
        public string ID { get; set; } = String.Empty;
        public string IdentityCardNumber { get; set; } = String.Empty;
        public string DrivingLicenseNumber { get; set; } = String.Empty;
        public string FullName { get; set; } = String.Empty;
        public string PlaceOfBirth { get; set; } = String.Empty;
        public DateTime DateOfBirth { get; set; }
        public int GenderID { get; set; }
        public int BloodTypeID { get; set; }
        public string AddressOfIdentityCard { get; set; } = String.Empty;
        public string AddressOfDrivingLicense { get; set; } = String.Empty;
        public int ReligionID { get; set; }
        public int MaritalStatusID { get; set; }
        public int NationalityID { get; set; }
        public int OccupationsIDOfIdentityCard { get; set; }
        public string OccupationsOthersOfIdentityCard { get; set; } = String.Empty;
        public int OccupationsIDOfDrivingLicense { get; set; }
        public string OccupationsOthersOfDrivingLicense { get; set; } = String.Empty;
        public DateTime ValidThruOfIdentityCard { get; set; }
        public DateTime ValidThruOfDrivingLicense { get; set; }
        public int DrivingLicenseTypeID { get; set; }
        public int Height { get; set; }
        public int StatusID { get; set; }
        public int CreatedFromComLocID { get; set; }
        public int LastUpdatedFromComLocID { get; set; }
        public string ReferencesID { get; set; } = String.Empty;
        public string InternalRemarks { get; set; } = String.Empty;
        public Status Status { get; set; } = new Status();
        public Gender Gender { get; set; } = new Gender();
        public BloodType BloodType { get; set; } = new BloodType();
        public Religion Religion { get; set; } = new Religion();
        public MaritalStatus MaritalStatus { get; set; } = new MaritalStatus();
        public Nationality Nationality { get; set; } = new Nationality();
    }
}
