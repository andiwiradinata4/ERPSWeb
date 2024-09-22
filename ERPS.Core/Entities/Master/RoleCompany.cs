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
    [Table("mstRoleCompany")]
    public class RoleCompany : BaseEntity
    {
        [MaxLength(100)]
        [ForeignKey("RoleProgram")]
        public string? RoleProgramId { get; set; }
        public RoleProgram? RoleProgram  { get; set; }
        [MaxLength(100)]
        [ForeignKey("Company")]
        public string? CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
