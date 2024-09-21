using ERPS.Core.Entities.Base.Interface;
using System.ComponentModel.DataAnnotations;

namespace ERPS.Core.Entities.Base
{
    public class BaseEntity : BaseEntityCustom, IEntityStandard, IBaseEntityStandard
    {
        [MaxLength(100)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}