using QArte.Persistance.PersistanceModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

using System.Threading;
using System.Threading.Tasks;

namespace QArte.Persistance
{
    public partial class QArteDBContext : DbContext
    {
        public QArteDBContext()
        {
        }

        public QArteDBContext(DbContextOptions<QArteDBContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<Fee> Fees { get; set; }
        public virtual DbSet<Gallery> Galleries { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<SettlementCycle> SettlementCycles { get; set; }
        public virtual DbSet<Role> Role { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.OriginalValues.Properties.Any(x => x.Name == "IsDeleted"))
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.CurrentValues["IsDeleted"] = false;
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            entry.CurrentValues["IsDeleted"] = true;
                            break;
                    }
                }
            }
        }

    }
}


