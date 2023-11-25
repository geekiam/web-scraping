using System.Reflection;
using System.Runtime.CompilerServices;
using Geekiam.Enrichment.MetagNames;
using Geekiam.Enrichment.Models;
using HtmlAgilityPack;

namespace Geekiam.Enrichment;

public class WebPageParser
{
    public async Task<MetaData> Extract(string url)
    {
       var htmlDoc = await new HtmlWeb().LoadFromWebAsync(url);
        
        return await Extract(htmlDoc);
    }

private static async Task<MetaData> Extract(HtmlDocument htmlDoc)
    {
        return new MetaData
        {
            Title = htmlDoc.DocumentNode.SelectSingleNode(MetaTagName.Title).InnerText.Trim(),
            Description = Extractor.GetMetaContent(htmlDoc, MetaTagName.Description),
            Twitter = new Twitter
            {
                Title = Extractor.GetMetaContent(htmlDoc, TwitterTagName.Title),
                Description = Extractor.GetMetaContent(htmlDoc, TwitterTagName.Description),
                Domain = Extractor.GetMetaContent(htmlDoc, TwitterTagName.Site),
                Creator = Extractor.GetMetaContent(htmlDoc, TwitterTagName.Creator),
            },
            OpenGraph = new OpenGraph
            {
                Title = Extractor.GetMetaContent(htmlDoc, OpenGraphTagName.Title)  ,
                Description = Extractor.GetMetaContent(htmlDoc, OpenGraphTagName.Description),
                Url = Extractor.GetMetaContent(htmlDoc, OpenGraphTagName.Url),
                Type = Extractor.GetMetaContent(htmlDoc, OpenGraphTagName.Type)
            }
        };
    }
    
  
  
  
  
  
  

   

    
}