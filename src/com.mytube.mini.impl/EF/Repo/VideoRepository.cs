using System.Collections.Generic;
using com.mytube.mini.core.Entities;
using System.Linq;

namespace com.mytube.mini.impl.EF.Repo
{
    public class VideoRepository : AbstractRepository, IRepository<Video>
    {
        public IEnumerable<Video> GetAll()
        {
            return context.Videos.ToList();
        }
    }
}
