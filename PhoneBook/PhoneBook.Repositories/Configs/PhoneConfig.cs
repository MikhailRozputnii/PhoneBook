using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Domains;

namespace PhoneBook.Repositories.Configs
{
    internal class PhoneConfig : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.Property(u => u.Name)
             .HasMaxLength(50);

            builder.Property(u => u.PhoneNumber)
               .IsRequired().HasMaxLength(15);

            builder.Property(u => u.Description)
               .HasMaxLength(254);
        }
    }
}
