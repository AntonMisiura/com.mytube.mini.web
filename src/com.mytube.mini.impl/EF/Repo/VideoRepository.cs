using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using com.mytube.mini.core.Contracts;
using com.mytube.mini.core.Entities;
using Microsoft.EntityFrameworkCore;

namespace com.mytube.mini.impl.EF.Repo
{
    public class VideoRepository : Repository<Video>, IVideoRepository
    {
        public VideoRepository(TubeContext context) : base(context)
        {
        }

        public IEnumerable<Video> GetByUser(CancellationToken token, int id)
        {
            return Context.Set<Video>().Where(e => e.UserId == id).ToList();
        }
    }
}
