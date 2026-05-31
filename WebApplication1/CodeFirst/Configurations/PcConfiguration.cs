using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations;

public class PcConfiguration : IEntityTypeConfiguration<Pc>
{
    public void Configure(EntityTypeBuilder<Pc> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).HasMaxLength(50);
        builder.Property(p => p.Weight).HasColumnType("float(5)");
        builder.Property(p => p.Warranty);
        builder.Property(p => p.CreatedAt).HasColumnType("date");
        builder.Property(p => p.Stock);
        
        builder.HasData(new List<Pc>()
        {
            new Pc { Id = 1, Name = "Dell XPS 15", Weight = 1.86, Warranty = 24, CreatedAt = new DateTime(2023, 5, 10), Stock = 15 },
            new Pc { Id = 2, Name = "HP Spectre x360", Weight = 1.34, Warranty = 12, CreatedAt = new DateTime(2022, 11, 3), Stock = 8 },
            new Pc { Id = 3, Name = "Lenovo ThinkPad X1", Weight = 1.12, Warranty = 36, CreatedAt = new DateTime(2024, 1, 20), Stock = 22 }
        });
        
        
    }
}