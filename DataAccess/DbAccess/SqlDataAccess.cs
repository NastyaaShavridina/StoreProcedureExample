using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.DbAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(
            string storeProcedure,
            U parameters,
            string connectionId = "Default")
        {
            using IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString(connectionId));

            return await dbConnection.QueryAsync<T>(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> SaveData<T>(
            string storeProcedure,
            T parameters,
            string connectionId = "Default")
        {
            using IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString(connectionId));

            return await dbConnection.ExecuteAsync(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
