using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations;

public class PcComponentConfiguration : IEntityTypeConfiguration<PcComponent>
{
    public void Configure(EntityTypeBuilder<PcComponent> builder)
    {
        builder.HasKey(x => new {x.PcId, x.ComponentCode});
        builder.Property(x => x.Amount);
        
        builder.HasOne(x => x.Pc)
            .WithMany(x => x.PcComponents)
            .HasForeignKey(x => x.PcId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Component)
            .WithMany(x => x.PcComponents)
            .HasForeignKey(x => x.ComponentCode)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasData(new List<PcComponent>()
        {
            new PcComponent { PcId = 1, ComponentCode = "GPU-RX580", Amount = 1 },
            new PcComponent { PcId = 2, ComponentCode = "CPU-R5600", Amount = 2 },
            new PcComponent { PcId = 3, ComponentCode = "RAM-16DDR4", Amount = 4 }
        });
    }
}