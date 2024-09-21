using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERPS.Core.Entities.Base;

namespace ERPS.Core.Entities
{
	[Table("mstStatus")]
	public class Status : BaseEntity
	{
		[MaxLength(100)]
		public string Code { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
	}
}