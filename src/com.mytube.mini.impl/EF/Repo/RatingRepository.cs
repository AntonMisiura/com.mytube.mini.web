using com.mytube.mini.core.Entities;

namespace com.mytube.mini.impl.EF.Repo
{
    public class RatingRepository : Repository<Rating>
    {
        public RatingRepository(TubeContext context) : base(context)
        {
        }
    }
}
