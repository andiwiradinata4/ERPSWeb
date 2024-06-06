using ERPS.Core.Models;

namespace ERPS.Core.Interfaces
{
    public interface INationalityRepository : IBaseRepository<Nationality>
    {
        Task<Nationality> CreateAsync(Nationality data);
        Task<Nationality> UpdateAsync(int id, Nationality data);
    }
}
