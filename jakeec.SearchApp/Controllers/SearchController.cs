using Microsoft.AspNetCore.Mvc;
using jakeec.SearchApp.SearchEngine;
using jakeec.SearchApp.Models;

namespace jakeec.SearchApp.Controllers;

public class SearchController : Controller
{
    private readonly ILogger<SearchController> _logger;
    private readonly ISearchEngine _searchEngine;

    public SearchController(ILogger<SearchController> logger, ISearchEngine searchEngine)
    {
        _logger = logger;
        _searchEngine = searchEngine;
    }

    public ActionResult<SearchResultModel> Index(string searchTerm)
    {
        return View(_searchEngine.Search(searchTerm));
    }
}
