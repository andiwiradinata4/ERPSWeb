using ERPS.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPS.Core.Entities
{
    [Table("mstRoleCompany")]
    public class RoleCompany: BaseEntity
    {
        [ForeignKey("Role")]
        public string? RoleId { get; set; }
        public Role? Role { get; set; }
        [ForeignKey("Company")]
        public string? CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
