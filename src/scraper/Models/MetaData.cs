namespace Geekiam.Enrichment.Models;

public class MetaData
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string  Summary { get; set; } = string.Empty;
    
    public IEnumerable<string> Keywords { get; set; } = new List<string>();
    public IEnumerable<string> Tags { get; set; } = new List<string>();
    
    public DateTime Published { get; set; } = DateTime.UtcNow;
    
    public Twitter Twitter { get; set; } = new Twitter();
    public OpenGraph OpenGraph { get; set; } = new OpenGraph();




}


