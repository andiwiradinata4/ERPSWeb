using ERPS.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPS.Core.Entities
{
    [Table("mstRoleModule")]
    public class RoleModule: BaseEntity
    {
        [ForeignKey("RoleCompany")]
        public string? RoleId { get; set; }
        public Role? Role { get; set; }
        [ForeignKey("Company")]
        public string? ModuleId { get; set; }
        public Module? Module { get; set; }        
    }
}