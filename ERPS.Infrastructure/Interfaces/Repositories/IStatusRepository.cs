using ERPS.Core.DbContext.v1;
using ERPS.Core.Entities.Master;
using ERPS.Infrastructure.Interfaces.Repositories.Base;

namespace ERPS.Infrastructure.Interfaces.Repositories
{
    public interface IStatusRepository : IBaseRepository<AppDBContext, Status>
	{

	}
}
