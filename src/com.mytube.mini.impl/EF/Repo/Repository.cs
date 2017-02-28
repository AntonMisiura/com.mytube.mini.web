using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.mytube.mini.core.Contracts;

namespace com.mytube.mini.impl.EF.Repo
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected TubeContext Context { get; private set; }

        public Repository(TubeContext context)
        {
            Context = context;
        }

        public T GetById(int id)
        {
            return Context.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public void Add(T t)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
