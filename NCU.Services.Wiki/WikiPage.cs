using Microsoft.IdentityModel.Protocols;
using System.Net;

namespace NCU.Services.Wiki;

public class WikiPage
{
    VersionHistoryRecord? VersionHistoryRecord { get; set; }
    public HashSet<string> Tags { get; set; } = new();
    public HashSet<WikiPage> Revisions { get; set; } = new();
}

#region Records 
public record VersionHistoryRecord(Guid Id, string Title, string Content, string ModifiedBy);
public record SearchRecord(Guid Id, string Title, string Content, string Author, DateTime CreatedAt);
public record CreateWikiPage(Guid Id, string Title, string Content, string Author, HashSet<string> tags);
public record EditWikiPage(Guid Id, string Title, string Content, string Author);
public record DeleteWikiPage(Guid Id, string Title, string Content, string Author);
public record AddTag(Guid Id, string Tag);
public record SearchWikiPage(string Query); 
#endregion



