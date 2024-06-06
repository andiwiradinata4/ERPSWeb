using ERPS.Core.Models;

namespace ERPS.Core.Interfaces
{
    public interface IReligionRepository : IBaseRepository<Religion>
    {
        Task<Religion> CreateAsync(Religion data);
        Task<Religion> UpdateAsync(int id, Religion data);
    }
}