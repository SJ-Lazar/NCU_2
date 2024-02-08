using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccess;
public class SqlDapperDataAccess
{
    /// <summary>
    /// Load a single row Data Using Dapper From Database Pass the Connection String and SQL Statement
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <param name="dbConnectionString"></param>
    /// <param name="sqlStatement"></param>
    /// <param name="parameters"></param>
    /// <returns>Data Mapped To Model Passed In When Method Is Invoked.</returns>
    public async Task<T?> LoadDataScalar<T, U>(string dbConnectionString, string sqlStatement, U parameters)
        => await ScalarQuery<T, U>(dbConnectionString, sqlStatement, parameters);
    /// <summary>
    ///Loads a list of data using Dapper from the database. Pass the connection string and SQL statement.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <param name="dbConnectionString"></param>
    /// <param name="sqlStatement"></param>
    /// <param name="parameters"></param>
    /// <returns>A list of the model passed in.</returns>
    public async Task<IEnumerable<T>?> LoadData<T, U>(string dbConnectionString, string sqlStatement, U parameters) 
            => await QueryAsync<T, U>(dbConnectionString, sqlStatement, parameters);
    /// <summary>
    /// Saves Data to the database using Dapper. Pass the connection string and SQL statement.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dbConnectionString"></param>
    /// <param name="sqlStatement"></param>
    /// <param name="parameters"></param>
    /// <returns>true of false.</returns>
    public async Task<bool> SaveData<T>(string dbConnectionString, string sqlStatement, T parameters) => 
        await Save(dbConnectionString, sqlStatement, parameters);

    string connectionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";

    #region Private Methods 
    private async Task<T?> ScalarQuery<T, U>(string dbConnectionString, string sqlStatement, U parameters)
    {
        try
        {
            using IDbConnection connection = new SqlConnection(dbConnectionString);
            var data = await connection.ExecuteScalarAsync<T>(sqlStatement, parameters);
            return data;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading data: {ex.Message}");
            return default;
        }
    }

    private async Task<IEnumerable<T>?> QueryAsync<T, U>(string dbConnectionString, string sqlStatement, U parameters)
    {
        try
        {
            using SqlConnection connection = new SqlConnection(dbConnectionString);
            connection.Open();
            var data = await connection.QueryAsync<T>(sqlStatement, parameters);
            return data;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading data: {ex.Message}");
            return default;
        }
    }

    private async Task<bool> Save<T>(string dbConnectionString, string sqlStatement, T parameters)
    {
        try
        {
            using IDbConnection connection = new SqlConnection(dbConnectionString);
            return await connection.ExecuteAsync(sqlStatement, parameters) > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving data: {ex.Message}");
            return false;
        }
    } 
    #endregion
}
