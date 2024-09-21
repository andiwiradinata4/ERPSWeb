using System.ComponentModel.DataAnnotations;

namespace ERPS.Core.Entities.Base.Interface
{
    public interface IBaseEntityStandard
    {
		[MaxLength(100)]
		string LogBy { get; set; }
		[MaxLength(500)]
		string LogByUserDisplayName { get; set; }
        DateTime LogDate { get; set; }
        DateTime LogDateUTC { get; set; }
        int LogInc { get; set; }
		[MaxLength(100)]
		string CreatedBy { get; set; }
		[MaxLength(500)]
		string CreatedByUserDisplayName { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime CreatedDateUTC { get; set; }
		[MaxLength(5000)]
		string Remarks { get; set; }
        bool Disabled { get; set; }
        [Timestamp]
        byte[] RowVersion { get; set; }
    }
}