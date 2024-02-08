using DataAccess;

namespace NCU.Services.Wiki;

public class WikiPagesCommandService
{
    public async Task<bool> Create(string dbConnectionString ,CreateWikiPage createWikiPage)
        => await new SqlDapperDataAccess().SaveData(dbConnectionString, CreateSqlStatement(), createWikiPage);

    public async Task<bool> Edit(string dbConnectionString, EditWikiPage editWikiPage)
        => await new SqlDapperDataAccess().SaveData(dbConnectionString, EditSqlStatement(), editWikiPage);

    public async Task<bool> Delete(string dbConnectionString, DeleteWikiPage deleteWikiPage)
        => await new SqlDapperDataAccess().SaveData(dbConnectionString, DeleteSqlStatement(), deleteWikiPage);

    #region Private Methods
    private string CreateSqlStatement()
    => $"INSERT INTO WikiPages (Id, Title, Content, Author, Tags)" +
    $" VALUES (@Id, @Title, @Content, @Author, @Tags)";

    private string EditSqlStatement()
        => $"UPDATE WikiPages SET Title = @Title, Content = @Content, Author = @Author WHERE Id = @Id";

    private string DeleteSqlStatement()
        => $"DELETE FROM WikiPages WHERE Id = @Id"; 
    #endregion
}




