using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using com.mytube.mini.core.Entities;
using System.Linq;
using com.mytube.mini.core.Contracts;
using Microsoft.EntityFrameworkCore;

namespace com.mytube.mini.impl.EF.Repo
{
    public class RatingRepository : Repository<Rating>, IRatingRepository
    {
        public RatingRepository(TubeContext context) : base(context)
        {
        }

        public IEnumerable<Rating> GetByVideoId(CancellationToken token, int id)
        {
            return Context.Set<Rating>().Where(e => e.VideoId == id).ToList();
        }
    }
}
