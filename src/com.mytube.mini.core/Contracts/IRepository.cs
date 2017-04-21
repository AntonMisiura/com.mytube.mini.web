using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace com.mytube.mini.core.Contracts
{
    public interface IRepository<T>
    {
        T GetById(CancellationToken token, int id);

        IEnumerable<T> GetAll(CancellationToken token);


        void Add(CancellationToken token, T t);

        bool Save(CancellationToken token);
    }
}
