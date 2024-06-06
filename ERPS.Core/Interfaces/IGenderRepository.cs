using ERPS.Core.Models;

namespace ERPS.Core.Interfaces
{
    public interface IGenderRepository : IBaseRepository<Gender>
    {
        Task<Gender> CreateAsync(Gender data);
        Task<Gender> UpdateAsync(int id, Gender data);
    }
}
