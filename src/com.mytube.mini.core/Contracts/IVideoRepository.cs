using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using com.mytube.mini.core.Entities;

namespace com.mytube.mini.core.Contracts
{
    public interface IVideoRepository : IRepository<Video>
    {
        Task<IEnumerable<Video>> GetByUser(CancellationToken token, int id);
    }
}
