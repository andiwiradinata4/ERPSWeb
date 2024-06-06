namespace ERPS.Application.Interfaces
{
    public interface IBaseService<T>
    {
        Task<List<T>> GetAllAsync(string[] includes);
        Task<T> GetByIDAsync(int id);
        Task<T> DeleteAsync(int id);
    }
}