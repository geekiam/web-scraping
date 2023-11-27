using Geekiam.Enrichment.MetagNames;
using Geekiam.Enrichment.Models;
using HtmlAgilityPack;

namespace Geekiam.Enrichment;

internal static class Extractor
{
    
    internal static Task<MetaData> Extract(HtmlDocument htmlDoc)
    {
        return Task.FromResult(new MetaData
        {
            Title = htmlDoc.DocumentNode.SelectSingleNode(MetaTagName.Title).InnerText.Trim(),
            Description = GetMetaContent(htmlDoc, MetaTagName.Description),
            Twitter = new Twitter
            {
                Title = GetMetaContent(htmlDoc, TwitterTagName.Title),
                Description = GetMetaContent(htmlDoc, TwitterTagName.Description),
                Domain = GetMetaContent(htmlDoc, TwitterTagName.Site),
                Creator = GetMetaContent(htmlDoc, TwitterTagName.Creator),
            },
            OpenGraph = new OpenGraph
            {
                Title = GetMetaContent(htmlDoc, OpenGraphTagName.Title)  ,
                Description = GetMetaContent(htmlDoc, OpenGraphTagName.Description),
                Url = GetMetaContent(htmlDoc, OpenGraphTagName.Url),
                Type = GetMetaContent(htmlDoc, OpenGraphTagName.Type)
            }
        });
    }
    
    internal static string GetMetaContent(HtmlDocument htmlDocument, string metaName)
    {
        if(htmlDocument.DocumentNode
               .SelectSingleNode($"//meta[@name='{metaName}']") is { } node)
        {
            return node                                    
                .GetAttributeValue(MetaTagName.Content, string.Empty);                                      
        }

        return string.Empty;
    }
}