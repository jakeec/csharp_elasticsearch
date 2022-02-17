namespace jakeec.SearchApp.SearchEngine;

using Elasticsearch.Net;
using jakeec.SearchApp.Models;
using Nest;

public class ElasticSearchEngine : ISearchEngine
{
    private readonly ILogger<ElasticSearchEngine> _logger;
    private readonly ElasticClient _client;

    public ElasticSearchEngine(ILogger<ElasticSearchEngine> logger, IConfiguration configuration)
    {
        _logger = logger;
        (string username, string password) = (configuration["Elasticsearch:BasicAuthentication:Username"], configuration["Elasticsearch:BasicAuthentication:Password"]);
        var settings = new ConnectionSettings(new Uri("https://localhost:9200"))
            .DefaultIndex("news_headlines")
            .BasicAuthentication(username, password)
            .ServerCertificateValidationCallback(CertificateValidations.AllowAll)
            .DisableDirectStreaming();
        _client = new ElasticClient(settings);
    }

    public SearchResultModel Search(string term)
    {
        var searchRequest = new SearchRequest<NewsHeadline>()
        {
            Query = new MatchQuery
            {
                Field = Infer.Field<NewsHeadline>(n => n.ShortDescription),
                Query = term,
                Operator = Operator.Or,
                Lenient = true
            }
        };
        var searchResponse = _client.Search<NewsHeadline>(searchRequest);
        var headlines = searchResponse.Documents;
        return new SearchResultModel {
            Results = headlines.ToList<NewsHeadline>()
        };
    }
}