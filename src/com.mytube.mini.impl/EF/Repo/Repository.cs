using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using com.mytube.mini.core.Contracts;
using Microsoft.EntityFrameworkCore;

namespace com.mytube.mini.impl.EF.Repo
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected TubeContext Context { get; private set; }

        public Repository(TubeContext context)
        {
            Context = context;
        }

        public async Task<T> GetById(int id)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<T>> GetAll(CancellationToken token)
        {
            return await Context.Set<T>().ToListAsync(token);
        }

        public Task Add(T t)
        {
            return Task.FromResult(Context.Add(t));
        }

        public async Task<bool> Save()
        {
            return await Context.SaveChangesAsync() > 0;
        }
    }
}
