using System.Collections.Generic;
using System.Linq;
using com.mytube.mini.core.Entities;

namespace com.mytube.mini.impl.EF.Repo
{
    public class RatingRepository : AbstractRepository, IRepository<Rating>
    {
        public IEnumerable<Rating> GetAll()
        {
            return context.Ratings.ToList();
        }
    }
}
