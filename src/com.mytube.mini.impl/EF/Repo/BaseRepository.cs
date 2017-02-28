namespace com.mytube.mini.impl.EF.Repo
{
    public abstract class BaseRepository
    {
        protected TubeContext Context { get; private set; }

        protected BaseRepository(TubeContext context)
        {
            Context = context;
        }
    }
}
