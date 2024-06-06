namespace ERPS.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(string[] includes);
        Task<T> GetByIDAsync(int id);
        Task<int> GetMaxID();
        Task<T> DeleteAsync(int id);
    }
}