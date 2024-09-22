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
    [Table("mstRoleModule")]
    public class RoleModule : BaseEntity
    {
        [MaxLength(100)]
        [ForeignKey("RoleCompany")]
        public string? RoleCompanyId { get; set; }
        public RoleCompany? RoleCompany { get; set; }
        [MaxLength(100)]
        [ForeignKey("Module")]
        public string? ModuleId { get; set; }
        public Module? Module { get; set; }
    }
}