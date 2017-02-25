using System.Collections.Generic;

namespace com.mytube.mini.impl.EF.Repo
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
    }
}
