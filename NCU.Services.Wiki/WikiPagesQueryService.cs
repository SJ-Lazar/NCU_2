using DataAccess;

namespace NCU.Services.Wiki;

public class WikiPagesQueryService
{
    public async Task<IEnumerable<WikiPage>> GetPages(string dbConnectionString) 
        => await new SqlDapperDataAccess().LoadData<WikiPage, dynamic>(dbConnectionString, "SELECT * FROM Pages", new { }) ?? Enumerable.Empty<WikiPage>();

    public async Task<WikiPage?> GetPage(string dbConnectionString, Guid id)
        => await new SqlDapperDataAccess().LoadDataScalar<WikiPage, dynamic>(dbConnectionString, "SELECT * FROM Pages WHERE Id = @Id", new { Id = id });

    public async Task<IEnumerable<WikiPage>> SearchPages(string dbConnectionString, string query)
        => await new SqlDapperDataAccess().LoadData<WikiPage, dynamic>(dbConnectionString, "SELECT * FROM Pages WHERE Title LIKE @Query OR Content LIKE @Query", new { Query = $"%{query}%" }) ?? Enumerable.Empty<WikiPage>();

    public async Task<IEnumerable<WikiPage>> GetRevisions(string dbConnectionString, Guid id)
        => await new SqlDapperDataAccess().LoadData<WikiPage, dynamic>(dbConnectionString, "SELECT * FROM Pages WHERE Id = @Id", new { Id = id }) ?? Enumerable.Empty<WikiPage>();

    public async Task<IEnumerable<string>> GetTags(string dbConnectionString)
        => await new SqlDapperDataAccess().LoadData<string, dynamic>(dbConnectionString, "SELECT * FROM Tags", new { }) ?? Enumerable.Empty<string>();
}




