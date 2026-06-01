using WebApplication1.Models;

namespace WebApplication1.DTOs;

public class PcWithComponentsDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }

    public IEnumerable<PcComponentsDto> pcComponents { get; set; } = [];
}

public class PcComponentsDto
{
    public int Amount { get; set; }
    public ComponentDto Component { get; set; }
}

public class ComponentDto
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public ComponentManufacturerDto Manufacturer { get; set; }
    public ComponentTypeDto Type { get; set; }
}

public class ComponentManufacturerDto
{
    public int Id { get; set; }
    public string Abbreviation { get; set; }
    public string FullName { get; set; }
    public DateTime FoundationDate { get; set; }
}

public class ComponentTypeDto
{
    public int Id { get; set; }
    public string Abbreviation { get; set; }
    public string Name { get; set; }
}