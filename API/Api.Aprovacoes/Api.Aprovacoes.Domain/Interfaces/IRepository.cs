using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Processos.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(int id);
        Task<T> SelectAsync(int id);
        Task<IEnumerable<T>> SelectAsync();
    }
}
