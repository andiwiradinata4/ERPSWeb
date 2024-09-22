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
    [Table("mstRoleAccess")]
    public class RoleAccess:BaseEntity
    {
        [MaxLength(100)]
        [ForeignKey("RoleModule")]
        public string? RoleModuleId { get; set; }
        public RoleModule? RoleModule { get; set; }
        [MaxLength(100)]
        [ForeignKey("Access")]
        public string? AccessId { get; set; }
        public Access? Access { get; set; }
    }
}