using System.ComponentModel;
using Geekiam.Enrichment;
using Geekiam.Enrichment.MetagNames;
using HtmlAgilityPack;
using Shouldly;

namespace Enrichment.Tests;

public class WebSiteParseTests
{
    [Fact]
    public async Task ShouldParseWebsite()
    {
        var parser = new WebPageParser();

        var result = await parser.Extract("https://garywoodfine.com/abstract-factory-design-pattern/");
        result.ShouldNotBeNull();
        
    }

    [Fact, Description("Should get an empty string returned for any tag that does exist")]
    public void ShouldGetEmptyStringForNonExistingTag()
    {
	    var poo = Extractor.GetMetaContent(TestDocument(), "random:tagName");
	    poo.ShouldNotBeNull();
	    poo.ShouldBe(string.Empty);
    }

    [Fact, Description("Should get a value for the title tag")]
    public void ShouldGetValueForTtileTag()
    {
	    var poo = Extractor.GetMetaContent(TestDocument(), TwitterTagName.Title);
	    poo.ShouldNotBeNull();
	    poo.ShouldBeEquivalentTo("How to add Tailwind CSS to Blazor website | Gary Woodfine");
    }

    private static HtmlDocument TestDocument()
    {
        var document = new HtmlDocument();
      document.LoadHtml(TestHtml);
      return document;


    }
    
    

    private static string TestHtml => @"
<html lang=""en-GB"">
<head>
	
	<meta charset=""UTF-8"">
	<meta name=""viewport"" content=""width=device-width, initial-scale=1, minimum-scale=1"">
	<link rel=""profile"" href=""http://gmpg.org/xfn/11"">
		<title>How to add Tailwind CSS to Blazor website | Gary Woodfine</title>
<meta name=""description"" content=""A walk-through guide detailing the steps you can follow to configure your Blazor wasm project to use Tailwind CSS."">
<meta name=""robots"" content=""index, follow"">
<meta name=""googlebot"" content=""index, follow, max-snippet:-1, max-image-preview:large, max-video-preview:-1"">
<meta name=""bingbot"" content=""index, follow, max-snippet:-1, max-image-preview:large, max-video-preview:-1"">
<link rel=""canonical"" href=""https://garywoodfine.com/how-to-add-tailwind-css-to-blazor-website/"">
<meta name=""twitter:card"" content=""summary_large_image"">
<meta name=""twitter:site"" content=""@gary_woodfine"">
<meta name=""twitter:creator"" content=""@gary_woodfine"">
<meta name=""twitter:title"" content=""How to add Tailwind CSS to Blazor website | Gary Woodfine"">
<meta name=""twitter:description"" content=""A walk-through guide detailing the steps you can follow to configure your Blazor wasm project to use Tailwind CSS."">
<meta name=""twitter:image"" content=""https://garywoodfine.com/wp-content/uploads/2022/07/dotnet-posts.png"">
<link rel=""alternate"" type=""application/rss+xml"" title=""Gary Woodfine &raquo; Feed"" href=""https://garywoodfine.com/feed/"" />
<link rel=""alternate"" type=""application/rss+xml"" title=""Gary Woodfine &raquo; Comments Feed"" href=""https://garywoodfine.com/comments/feed/"" />
</head>
</html>
";
}