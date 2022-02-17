using jakeec.SearchApp.Models;

namespace jakeec.SearchApp.SearchEngine;

public interface ISearchEngine
{
    SearchResultModel Search(string term);
}