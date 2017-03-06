using System.Threading.Tasks;
using com.mytube.mini.core.Entities;

namespace com.mytube.mini.core.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByLogin(string login);
    }
}
