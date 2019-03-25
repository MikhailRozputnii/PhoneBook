using Microsoft.EntityFrameworkCore;
using PhoneBook.Domains;
using PhoneBook.Repositories.Configs;

namespace PhoneBook.Repositories.Data
{
    public class PhoneBookDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Phone> Phones { get; set; }

        public PhoneBookDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new PhoneConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
