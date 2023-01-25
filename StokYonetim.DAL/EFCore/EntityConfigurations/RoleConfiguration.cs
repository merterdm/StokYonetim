using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StokYonetim.Entites;

namespace StokYonetim.DAL.EFCore.EntityConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.Property(p => p.Name).HasMaxLength(50);
            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Name).IsUnique(); // Role Name'e gore unique olacak

            builder.HasMany(p => p.UserRoles)
                    .WithOne(p => p.Role)
                    .HasForeignKey(p => p.RoleId);
        }
    }
}
