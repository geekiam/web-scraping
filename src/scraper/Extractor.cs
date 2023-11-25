using Geekiam.Enrichment.MetagNames;
using HtmlAgilityPack;

namespace Geekiam.Enrichment;

internal static class Extractor
{
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