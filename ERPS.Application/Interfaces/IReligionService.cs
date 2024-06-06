using ERPS.Core.Models;

namespace ERPS.Application.Interfaces
{
    public interface IReligionService : IBaseService<Religion>
    {
        Task<Religion> CreateAsync(Religion data);
        Task<Religion> UpdateAsync(int id, Religion data);
    }
}
