using System;
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

        public T GetById(CancellationToken token, int id)
        {
            return Context.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<T> GetAll(CancellationToken token)
        {
            return Context.Set<T>().ToList();
        }

        public void Add(CancellationToken token, T t)
        {
            var creatable = t as IEntityCreatable;
            if (creatable != null)
            {
                creatable.Create();
                creatable.CreatedDate = DateTime.UtcNow;
            }

            //return Task.FromResult(Context.Add(t));
        }

        public bool Save(CancellationToken token)
        {
            return Context.SaveChanges() > 0;
        }
    }
}
