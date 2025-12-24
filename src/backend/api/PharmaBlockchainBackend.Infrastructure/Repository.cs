using Microsoft.EntityFrameworkCore;

namespace PharmaBlockchainBackend.Infrastructure
{
    public interface IRepository<TEntity>
        where TEntity : DbSet<TEntity>
    {
        public DbSet<TEntity> DbSet { get; }
    }

    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : DbSet<TEntity>
    {
        public DbSet<TEntity> DbSet { get; }

        public Repository(DbSet<TEntity> dbSet)
        {
            DbSet = dbSet;
        }
    }
}
