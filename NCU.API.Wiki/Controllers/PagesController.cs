using Microsoft.AspNetCore.Mvc;
namespace NCU.API.Wiki.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PagesController : ControllerBase
{
    private readonly WikiPagesService _wikiPagesService;

    //	Content Creation: Registered users should be able to create new Wiki pages.The content creation interface should support text formatting options like bold, italic, underline, and hyperlinking.
    //	Content Editing: Registered users should be able to edit existing Wiki pages.The changes should be saved and reflected immediately.
    //	Content Deletion: Registered users should be able to delete Wiki pages that they have created.
    //	Search Functionality: The Wiki should have a search bar that allows users to search for specific Wiki pages.
    //	Version Control: The Wiki should keep track of all changes made to a page and allow users to revert to any previous version.

    //	async Pages/api/createPage: POST endpoint to create a new Wiki page.
    //	async Pages/api/editPage/{ pageId}: PUT endpoint to edit an existing Wiki page.
    //	async Pages/api/deletePage/{ pageId}: DELETE endpoint to delete a Wiki page.
    //	async Pages/api/search/{query
    // GET endpoint to search for Wiki pages.

    public PagesController(WikiPagesService wikiPagesService)
    {
        _wikiPagesService = wikiPagesService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePage()
        => _wikiPagesService.Cretae(); 

}
