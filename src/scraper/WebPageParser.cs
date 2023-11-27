using Geekiam.Enrichment.Models;
using HtmlAgilityPack;

namespace Geekiam.Enrichment;

public class WebPageParser
{
    public async Task<MetaData> Extract(string url)
    {
        ArgumentException.ThrowIfNullOrEmpty(url, nameof(url));
       
        var htmlDoc = await new HtmlWeb().LoadFromWebAsync(url);
        
        return await Extractor.Extract(htmlDoc);
    }


    
  
  
  
  
  
  

   

    
}