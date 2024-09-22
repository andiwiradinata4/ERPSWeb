using ERPS.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPS.Core.Entities.Master
{
    [Table("mstAccess")]
    public class Access : BaseEntity
    {
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
    }
}
