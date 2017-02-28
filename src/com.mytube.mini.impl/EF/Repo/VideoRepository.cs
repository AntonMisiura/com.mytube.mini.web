using com.mytube.mini.core.Entities;

namespace com.mytube.mini.impl.EF.Repo
{
    public class VideoRepository : Repository<Video>
    {
        public VideoRepository(TubeContext context) : base(context)
        {
        }
    }
}
