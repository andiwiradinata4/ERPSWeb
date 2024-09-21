using ERPS.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPS.Core.Entities
{
    public class UserCompany : BaseEntity
    {
        [ForeignKey("AppUser")]
        public string? UserId { get; set; }
        public AppUser? User { get; set; }
        [ForeignKey("Company")]
        public string? CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}