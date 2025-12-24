using Microsoft.EntityFrameworkCore;

namespace PharmaBlockchainBackend.Infrastructure
{
    public class PharmaBlockchainBackendDbContext(DbContextOptions<PharmaBlockchainBackendDbContext> options) : DbContext(options)
    {
        #region DbSets



        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public static void ApplyMigrations(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PharmaBlockchainBackendDbContext>().UseNpgsql(connectionString);
            var db = new PharmaBlockchainBackendDbContext(optionsBuilder.Options).Database;
            var pendingMigrations = db.GetPendingMigrations();

            if (pendingMigrations.Any())
                db.Migrate();
        }
    }
}
