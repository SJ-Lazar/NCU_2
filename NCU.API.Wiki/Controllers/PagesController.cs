using Microsoft.AspNetCore.Mvc;
using NCU.Services.Wiki;
namespace NCU.API.Wiki.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PagesController : ControllerBase
{
    private readonly WikiPagesCommandService _wikiPagesCommandService;
    private readonly WikiPagesQueryService _wikiPagesQueryService;
    private string _connectionString = string.Empty;
    private readonly IConfiguration _configuration;

    public PagesController(WikiPagesCommandService wikiPagesCommandService, IConfiguration configuration, WikiPagesQueryService wikiPagesQueryService)
    {
        _wikiPagesCommandService = wikiPagesCommandService;
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("WikiDb") ?? string.Empty;
        _wikiPagesQueryService = wikiPagesQueryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPages()
    {
        var pages = await _wikiPagesQueryService.GetPages(_connectionString);
        return Ok(pages);
    }

    [HttpPost]
    public async Task<ActionResult> CreatePage(CreateWikiPage createWikiPage)
        =>  Ok(await _wikiPagesCommandService.Create(_connectionString, createWikiPage));

}
