using Microsoft.EntityFrameworkCore;
using PersonalFinance.DataAccess.Contexts;

namespace PersonalFinance.API.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected PersonalFinanceContext _context { get; set; }
        private DbSet<T> _dbSet { get; set; }

        public Repository(PersonalFinanceContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
