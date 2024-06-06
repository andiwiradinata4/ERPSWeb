using ERPS.Core.Models;

namespace ERPS.Application.Interfaces
{
    public interface IGenderService : IBaseService<Gender>
    {
        Task<Gender> CreateAsync(Gender data);
        Task<Gender> UpdateAsync(int id, Gender data);
    }
}