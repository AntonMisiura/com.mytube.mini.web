using com.mytube.mini.core.Contracts;
using com.mytube.mini.core.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace com.mytube.mini.impl.EF.Repo
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(TubeContext context) : base(context)
        {
        }


        public async Task<User> GetByLogin(string login)
        {
            return await Context.Set<User>().FirstOrDefaultAsync(e => e.Login == login);
        }
    }
}
