using DataAccess;
using System.Net;

namespace NCU.Services.Wiki;

public class WikiPagesService
{
    private async Task<bool> Create(CreateWikiPage createWikiPage)
        => await new SqlDapperDataAccess().SaveData("connectionString", "sqlStatement", createWikiPage);

    private async Task<bool> Edit(EditWikiPage editWikiPage)
        => await new SqlDapperDataAccess().SaveData("connectionString", "sqlStatement", editWikiPage);

    private async Task<bool> Delete(DeleteWikiPage deleteWikiPage)
        => await new SqlDapperDataAccess().SaveData("connectionString", "sqlStatement", deleteWikiPage);
}

public class WikiPage()
{
    public HashSet<string> Tags { get; set; } = new();
    public HashSet<WikiPage> Revisions { get; set; } = new();
}

public record VersionHistoryRecord(Guid Id, string Title, string Content, string ModifiedBy);
public record SearchRecord(Guid Id, string Title, string Content, string Author, DateTime CreatedAt);
public record CreateWikiPage(Guid Id, string Title, string Content, string Author, HashSet<string> tags);
public record EditWikiPage(Guid Id, string Title, string Content, string Author);
public record DeleteWikiPage(Guid Id, string Title, string Content, string Author);

public record AddTag(Guid Id, string Tag);

public record SearchWikiPage(string Query);

public class WikiPageRevisionService
{
   //Revision related operations will be handled here
}

public class WikiPageSearchService
{
    //All Search related operations will be handled here 
}
