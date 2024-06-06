using ERPS.Core.Models;

namespace ERPS.Core.Interfaces
{
    public interface IMaritalStatusRepository : IBaseRepository<MaritalStatus>
    {
        Task<MaritalStatus> CreateAsync(MaritalStatus data);
        Task<MaritalStatus> UpdateAsync(int id, MaritalStatus data);
    }
}
