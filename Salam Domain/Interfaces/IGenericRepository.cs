using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Salam_Domain.Interfaces
{
    public interface IGeneric_Repository< T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(
         params Expression<Func<T, object>>[] includes
     );
        Task <T>GetByIdAsync(int id);

        Task AddAsync(T entity);
        void  UpdateAsync(T entity);

        void DeleteAsync(T entity);


    }
}
