using ERPS.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPS.Core
{
    [Table("mstRole")]
    public class Role
    {
        [MaxLength(100)]
        public string Code { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        public IEnumerable<RoleAccess> RoleAccesses { get; set; } = new List<RoleAccess>();
    }
}
