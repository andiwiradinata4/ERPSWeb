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
    [Table("mstRoleProgram")]
    public class RoleProgram : BaseEntity
    {
        [MaxLength(100)]
        [ForeignKey("Role")]
        public string? RoleId { get; set; }
        public Role? Role { get; set; }
        [MaxLength(100)]
        [ForeignKey("Program")]
        public string? ProgramId { get; set; }
        public Program? Program { get; set; }
    }
}
