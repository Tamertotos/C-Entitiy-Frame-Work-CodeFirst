namespace WebApplication1.Models;

public class PcComponent
{
    public int PcId { get; set; }
    public string ComponentCode { get; set; }
    public int Amount { get; set; }
    
    public Pc Pc { get; set; }
    public Component Component { get; set; }
}