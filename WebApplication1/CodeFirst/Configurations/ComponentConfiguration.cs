using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations;

public class ComponentConfiguration : IEntityTypeConfiguration<Component>
{
    public void Configure(EntityTypeBuilder<Component> builder)
    {
        builder.HasKey(x => x.Code);
        builder.Property(x => x.Code).HasMaxLength(10).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(300);
        builder.Property(x => x.Description).HasColumnType("nvarchar(max)");
        
        builder.HasOne(x => x.ComponentManufacturer).
            WithMany(x => x.Components).
            HasForeignKey(x => x.ComponentManufacturerId);
        
        builder.HasOne(x => x.ComponentType).
            WithMany(x => x.Components).
            HasForeignKey(x => x.ComponentTypeId);
        
        builder.HasData(new List<Component>()
        {
            new Component { Code = "GPU-RX580", Name = "Radeon RX 580", Description = "AMD mid-range graphics card released in 2017", ComponentTypeId = 1, ComponentManufacturerId = 1 },
            new Component { Code = "CPU-R5600", Name = "Ryzen 5 5600X", Description = "AMD 6-core high performance desktop processor", ComponentTypeId = 2, ComponentManufacturerId = 2 },
            new Component { Code = "RAM-16DDR4", Name = "Corsair 16GB DDR4", Description = "16GB DDR4 3200MHz desktop memory module", ComponentTypeId = 3, ComponentManufacturerId = 3 }
        });
    }
}