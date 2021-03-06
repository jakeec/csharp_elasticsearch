using Nest;

namespace jakeec.SearchApp.Models;

public class NewsHeadline
{
    public DateTime Date { get; set; }
    [Text(Name = "short_description")]
    public string? ShortDescription { get; set; }
    public string? Link { get; set; }
    public string? Category { get; set; }
    public string? Headline { get; set; }
    public string? Authors { get; set; }
}

public class SearchResultModel
{
    public List<NewsHeadline>? Results { get; set; }
}
