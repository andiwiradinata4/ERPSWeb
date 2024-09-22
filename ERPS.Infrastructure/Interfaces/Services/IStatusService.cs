using ERPS.Core.DbContext.v1;
using ERPS.Core.Entities.Master;

namespace ERPS.Infrastructure.Interfaces.Services
{
    public interface IStatusService : IBaseService<AppDBContext, Status>
    {

    }
}
