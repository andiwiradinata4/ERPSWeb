using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPS.Core.Entities.Base.Interface
{
    public interface IEntityStandard
    {
        [Key]
		[MaxLength(100)]
		string Id { get; set; }
    }
}
