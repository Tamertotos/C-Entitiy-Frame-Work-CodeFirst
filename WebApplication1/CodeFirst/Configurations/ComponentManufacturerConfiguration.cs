using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations;

public class ComponentManufacturerConfiguration : IEntityTypeConfiguration<ComponentManufacturer>
{
    public void Configure(EntityTypeBuilder<ComponentManufacturer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Abbreviation).HasMaxLength(30);
        builder.Property(x => x.FullName).HasMaxLength(300);
        builder.Property(x => x.FoundationDate).HasColumnType("date");

        builder.HasData(new List<ComponentManufacturer>()
        {
            new ComponentManufacturer { Id = 1, Abbreviation = "ASUS", FullName = "ASUSTeK Computer Inc.", FoundationDate = new DateTime(1989, 4, 2) },
            new ComponentManufacturer { Id = 2, Abbreviation = "MSI", FullName = "Micro-Star International Co.", FoundationDate = new DateTime(1986, 8, 4) },
            new ComponentManufacturer { Id = 3, Abbreviation = "EVGA", FullName = "EVGA Corporation", FoundationDate = new DateTime(1999, 8, 2) }
        });
    }
}