using ERPS.Core.Models;

namespace ERPS.Application.Interfaces
{
    public interface INationalityService : IBaseService<Nationality>
    {
        Task<Nationality> CreateAsync(Nationality data);
        Task<Nationality> UpdateAsync(int id, Nationality data);
    }
}