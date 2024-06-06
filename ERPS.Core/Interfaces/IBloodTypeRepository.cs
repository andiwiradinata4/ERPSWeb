using ERPS.Core.Models;

namespace ERPS.Core.Interfaces
{
    public interface IBloodTypeRepository : IBaseRepository<BloodType>
    {
        Task<List<BloodType>> GetAllWithIncludes(string[] includes);
        Task<BloodType> CreateAsync(BloodType data);
        Task<BloodType> UpdateAsync(int id, BloodType data);
    }
}