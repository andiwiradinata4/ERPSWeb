using ERPS.Core.Models;

namespace ERPS.Application.Interfaces
{
    public interface IStatusService: IBaseService<Status>
    {
        Task<Status> CreateAsync(Status data);
        Task<Status> UpdateAsync(int id, Status data);
    }
}
