using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPS.Core.Entities
{
    [Table("mstRoleAccess")]
    public class RoleAccess
    {
        [ForeignKey("RoleModule")]
        public string? RoleModuleId { get; set; }
        public RoleModule? RoleModule { get; set; }
        [ForeignKey("Access")]
        public string? AccessId { get; set; }
        public Access? Access { get; set; }
    }
}