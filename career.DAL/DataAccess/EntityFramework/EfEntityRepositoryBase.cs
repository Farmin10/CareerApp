using career.DAL.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace career.DAL.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<T> : IEntityRepository<T> where T : class, new()
    {
        DbContext _context;
        DbSet<T> _dbSet;

        public EfEntityRepositoryBase(CareerContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void AddRange(List<T> entity)
        {
            _dbSet.AddRange(entity);
        }

        public int Count(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;
            if (predicate!=null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties != null)
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }
            return query.Count();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public List<T> Get()
        {
            return _dbSet.ToList();
        }

        public List<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefaultAsync(predicate);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void UpdateRange(List<T> entity)
        {
            _dbSet.UpdateRange(entity);
        }
    }
}

