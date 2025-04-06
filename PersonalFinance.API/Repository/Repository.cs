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

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            T entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(QueryOptions<T> options)
        {
            IQueryable<T> query = _dbSet;
            if (options.HasWhere) 
            {
                query = query.Where(options.Where);
            }
            if (options.HasOrderBy) 
            {
                query = query.OrderBy(options.OrderBy);
            }
            foreach (var include in options.GetIncludes())
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, QueryOptions<T> options)
        {
            IQueryable<T> query = _dbSet;
            if (options.HasWhere)
            {
                query = query.Where(options.Where);
            }
            if (options.HasOrderBy)
            {
                query = query.OrderBy(options.OrderBy);
            }
            foreach (var include in options.GetIncludes())
            {
                query = query.Include(include);
            }

            var key = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.FirstOrDefault();
            string primaryKeyName = key?.Name ?? string.Empty;

            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, primaryKeyName) == id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
