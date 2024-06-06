using ERPS.Core.Models;

namespace ERPS.Core.Interfaces
{
    public interface IStatusRepository: IBaseRepository<Status>
    {
        Task<Status> CreateAsync(Status data);
        Task<Status> UpdateAsync(int id, Status data);
    }
}