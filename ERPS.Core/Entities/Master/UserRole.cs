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
    [Table("mstUserRole")]
    public class UserRole : BaseEntity
    {
        [ForeignKey("AppUser")]
        public string? UserId { get; set; }
        public AppUser? User { get; set; }
        [MaxLength(100)]
        [ForeignKey("RoleProgram")]
        public string? RoleProgramId { get; set; }
        public RoleProgram? RoleProgram { get; set; }
    }
}
