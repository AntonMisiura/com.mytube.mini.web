using System.Collections.Generic;
using com.mytube.mini.core.Entities;
using System.Linq;

namespace com.mytube.mini.impl.EF.Repo
{
    public class UserRepository : AbstractRepository, IRepository<User>
    {
        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
        }
    }
}
