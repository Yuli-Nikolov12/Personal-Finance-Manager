namespace PersonalFinance.API.Repository
{
    public interface IRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAllAsync(QueryOptions<T> options);
        Task<T> GetByIdAsync(int id, QueryOptions<T> options);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
