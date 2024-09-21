using ERPS.Core.Entities;
using ERPS.Infrastructure.Data.v1;
using ERPS.Infrastructure.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPS.Infrastructure.Interfaces.Repositories
{
	public interface IStatusRepository : IBaseRepository<AppDBContext, Status>
	{

	}
}
