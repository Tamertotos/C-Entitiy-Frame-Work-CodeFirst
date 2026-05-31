namespace WebApplication1.Models;

public class Component
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public int ComponentTypeId { get; set; }
    public ComponentType ComponentType{ get; set; }
    
    public int ComponentManufacturerId { get; set; }
    public ComponentManufacturer ComponentManufacturer { get; set; }
    
    public ICollection<PcComponent> PcComponents { get; set; }
}