using System;
using System.Collections.Generic;
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

        public async Task<T> GetById(CancellationToken token, int id)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<T>> GetAll(CancellationToken token)
        {
            return await Context.Set<T>().ToListAsync(token);
        }

        public Task Add(CancellationToken token, T t)
        {
            var creatable = t as IEntityCreatable;
            if (creatable != null)
            {
                creatable.Create();
                creatable.CreatedDate = DateTime.UtcNow;
            }

            return Task.FromResult(Context.Add(t));
        }

        public async Task<bool> Save(CancellationToken token)
        {
            return await Context.SaveChangesAsync() > 0;
        }
    }
}
