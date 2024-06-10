namespace ERPS.Application.Interfaces.v1
{
    public interface IBaseService<T>
    {
        Task<List<T>> GetAllAsync(string[] includes);
        Task<T> GetByIDAsync(dynamic id);
        Task<T> DeleteAsync(dynamic id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(dynamic id, T entity);
    }
}