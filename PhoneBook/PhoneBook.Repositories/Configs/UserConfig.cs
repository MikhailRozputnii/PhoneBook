using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Domains;

namespace PhoneBook.Repositories.Configs
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.PasswordHash)
               .IsRequired();

            builder.Property(u => u.Email)
               .IsRequired().HasMaxLength(40);

            builder.HasIndex(u => u.Email)
               .IsUnique();

            builder.HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
