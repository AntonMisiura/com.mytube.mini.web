using com.mytube.mini.core.Contracts;
using com.mytube.mini.core.Entities;
using System.Linq;

namespace com.mytube.mini.impl.EF.Repo
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(TubeContext context) : base(context)
        {
        }


        public User GetByLogin(string login)
        {
            return Context.Set<User>().FirstOrDefault(e => e.Login == login);
        }
    }
}
