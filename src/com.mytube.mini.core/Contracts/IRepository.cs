using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace com.mytube.mini.core.Contracts
{
    public interface IRepository<T>
    {
        Task<T> GetById(CancellationToken token, int id);

        Task<IEnumerable<T>> GetAll(CancellationToken token);

        Task Add(CancellationToken token, T t);

        Task<bool> Save(CancellationToken token);
    }
}
