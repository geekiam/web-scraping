using System.ComponentModel;
using Geekiam.Enrichment;
using Geekiam.Enrichment.MetagNames;
using HtmlAgilityPack;
using Shouldly;

namespace Geekiam.Enrichment.Tests;

public class WebSiteParseTests
{

	[Fact, Description("Should throw an exception if url is null or empty")]
	public async Task ShouldThrowExceptionIfUrlIsNullOrEmpty()
	{
		var parser = new WebPageParser();
		await Should.ThrowAsync<ArgumentException>(async () => await parser.Extract(string.Empty));
	}
	
    [Fact, Description("Should parse a website and return a MetaData object")]
    public async Task ShouldParseWebsite()
    {
        var parser = new WebPageParser();
        var result = await parser.Extract("https://garywoodfine.com/abstract-factory-design-pattern/");
        
        result.ShouldSatisfyAllConditions(
	        x => x.ShouldNotBeNull(),
	        x => x.Title.ShouldBe("How to use the Abstract Factory design pattern in C# | Gary Woodfine"),
	        x => x.Description.ShouldBe("Learn how to use the Abstract Factory .NET Design Pattern C# in order to help improve and enhance your code for greater testability.")
	        );
    }

    [Fact, Description("Should get an empty string returned for any tag that does exist")]
    public void ShouldGetEmptyStringForNonExistingTag()
    {
	    var result = Extractor.GetMetaContent(TestDocument(), "random:tagName");
	    result.ShouldSatisfyAllConditions(
		    x =>x.ShouldNotBeNull(x),
		    x => x.ShouldBe(string.Empty)
		    );
	   
    }

    [Fact, Description("Should get a value for the title tag")]
    public void ShouldGetValueForTitleTag()
    {
	    var result = Extractor.GetMetaContent(TestDocument(), TwitterTagName.Title);
	    
	    result.ShouldSatisfyAllConditions(
		    x => x.ShouldNotBeNull(),
		    x => x.ShouldBeOfType<string>(),
		    x => x.ShouldBeEquivalentTo("How to add Tailwind CSS to Blazor website | Gary Woodfine")
		    );
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