using ERPS.Core.Models;

namespace ERPS.Application.Interfaces
{
    public interface IBloodTypeService : IBaseService<BloodType>
    {
        Task<List<BloodType>> GetAllWithIncludes(string[] includes);
        Task<BloodType> CreateAsync(BloodType data);
        Task<BloodType> UpdateAsync(int id, BloodType data);
    }
}