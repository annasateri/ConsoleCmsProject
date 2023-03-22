using ConsoleCmsProject.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleCmsProject.Contexts
{
    internal class DataContext : DbContext
    {
        private readonly string _connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AnnaSäteri\Desktop\database\local_db.mdf;Integrated Security=True;Connect Timeout=30";


        #region context and overrides
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionstring);
        }
        #endregion

        public DbSet<ErrandEntity> Errands { get; set; } = null!;
        public DbSet<CustomerEntity> Customers { get; set; } = null!;
        public DbSet<AddressEntity> Addresses { get; set; } = null!;
        public DbSet<CommentEntity> Comments { get; set; }
    }
}