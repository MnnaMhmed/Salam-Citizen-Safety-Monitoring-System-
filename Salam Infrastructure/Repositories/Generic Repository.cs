using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Salam_Domain.Interfaces;
using Salam_Infrastructure.DBContext;

namespace Salam_Infrastructure.Repositories
{
    public class Generic_Repository<T> : IGeneric_Repository<T> where T : class
    {
        private readonly SalamDBContext _Context;
        private readonly DbSet<T> _dbSet;

        public Generic_Repository( SalamDBContext Context )
        {
            _Context = Context;
            _dbSet = Context.Set<T>();
        }
       async Task<IEnumerable<T>> IGeneric_Repository<T>.GetAllAsync(params Expression<Func<T, object>>[] includes)



        {
            IQueryable<T> query = _dbSet;
                if (includes!= null)
            {
                foreach (var include in includes)
                    query = query.Include(include);
            }
                return await query.ToListAsync();


        }
        async Task<T> IGeneric_Repository<T>.GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);

        }
        async Task IGeneric_Repository<T>.AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);

        }

        async void IGeneric_Repository<T>.DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
        }
       

        void IGeneric_Repository<T>.UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }

       
    }
}
