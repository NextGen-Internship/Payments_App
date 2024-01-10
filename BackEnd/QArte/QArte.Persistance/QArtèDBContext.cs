using QArte.Persistance.PersistanceModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace QArte.Persistance
{
    public partial class QArtèDBContext : DbContext
    {
        public QArtèDBContext()
        {
        }

        public QArtèDBContext(DbContextOptions<QArtèDBContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<BanTable> BanTables { get; set; }
        public virtual DbSet<Fee> Fees { get; set; }
        public virtual DbSet<Gallery> Galleries { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<SettlementCycle> SettlementCycles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=QArte;User Id=sa;Password=PassWord123;TrustServerCertificate=True");
            }
        }
    }
}


