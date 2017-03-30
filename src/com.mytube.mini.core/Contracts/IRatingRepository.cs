using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using com.mytube.mini.core.Entities;

namespace com.mytube.mini.core.Contracts
{
    public interface IRatingRepository : IRepository<Rating>
    {
        Task<IEnumerable<Rating>> GetByVideoId(CancellationToken token, int id);
    }
}
