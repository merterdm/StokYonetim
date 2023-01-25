using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StokYonetim.Entites;

namespace StokYonetim.DAL.EFCore.EntityConfigurations
{
    public class StokConfiguration : IEntityTypeConfiguration<Stok>
    {
        public void Configure(EntityTypeBuilder<Stok> builder)
        {


            builder.Property(p => p.StokAdi).HasMaxLength(50);
            builder.Property(p => p.Birim).HasMaxLength(20);


            builder.HasKey(p => p.Id); // Primary Key olarak isaretleyecek

            builder.HasOne(p => p.Kategori)
                    .WithMany(k => k.Stoklar)
                    .HasForeignKey(p => p.KategoriId)
                    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
