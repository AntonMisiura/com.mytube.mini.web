using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.mytube.mini.core.Contracts
{
    public interface IRepository<T>
    {
        T GetById(int id);

        IEnumerable<T> GetAll();

        void Add(T t);

        Task<bool> SaveChangesAsync();
    }
}
