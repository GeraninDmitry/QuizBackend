using Dapper;
using Microsoft.Data.SqlClient;
using Npgsql;

namespace ArtQuiz.Infrastructure.Storage
{
    public abstract class DataStorageBase
    {
        private readonly string _connectionString;

        protected DataStorageBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected async Task<NpgsqlConnection> OpenAsync(CancellationToken cancellationToken)
        {
            var connection = new NpgsqlConnection(_connectionString);

            await connection.OpenAsync(cancellationToken);

            return connection;
        }

        protected async Task<SqlMapper.GridReader> QueryMultipleAsync(string sqlQueryName, object parameters,
            CancellationToken cancellationToken = default, int? commandTimeout = null)
        {
            var connection = await OpenAsync(cancellationToken);

            return await connection.QueryMultipleAsync(GetSqlQuery(sqlQueryName), parameters,
                commandTimeout: commandTimeout);
        }

        protected async Task<T> QueryFirstOrDefaultAsync<T>(string sqlQueryName, object parameters,
            CancellationToken cancellationToken = default)
        {
            await using var connection = await OpenAsync(cancellationToken);

            return await connection.QueryFirstOrDefaultAsync<T>(GetSqlQuery(sqlQueryName), parameters);
        }

        protected async Task<dynamic> SqlFirstOrDefaultAsync(string sql, object parameters,
            CancellationToken cancellationToken = default)
        {
            await using var connection = await OpenAsync(cancellationToken);

            return await connection.QueryFirstOrDefaultAsync(sql, parameters);
        }

        protected async Task<int> ExecuteQueryAsync(string sqlQueryName, object parameters, int? commandTimeout = null,
            CancellationToken cancellationToken = default)
        {
            await using var connection = await OpenAsync(cancellationToken);

            return await connection.ExecuteAsync(GetSqlQuery(sqlQueryName), parameters, commandTimeout: commandTimeout);
        }

        protected virtual string GetResourceQueryName(string queryName)
        {
            return $"Sql.{queryName}.sql";
        }

        protected virtual string GetSqlQuery(string name)
        {
            var fullName = GetResourceQueryName(name);
            var query = GetString(fullName);
            if (string.IsNullOrEmpty(query))
                throw new InvalidOperationException($"SQL query '{name}' not found.");

            return query;
        }

        protected virtual string GetMultipleSqlQuery(params string[] names)
        {
            var query = "";

            foreach (var name in names)
            {
                if (!string.IsNullOrEmpty(name))
                {
                    var fullName = GetResourceQueryName(name);
                    query += GetString(fullName);
                    if (string.IsNullOrEmpty(query))
                        throw new InvalidOperationException($"SQL query '{names}' not found.");

                    query += $"; {Environment.NewLine}";
                }
            }

            return query;
        }

        private string GetString(string name)
        {
            return GetString(GetType().Assembly, name);
        }

        private string GetString(System.Reflection.Assembly assembly, string name)
        {
            using var reader = GetStream(assembly, name);
            var data = reader?.ReadToEnd();
            return data;
        }

        private StreamReader GetStream(System.Reflection.Assembly assembly, string name)
        {
            return (from resName in assembly.GetManifestResourceNames()
                where resName.EndsWith(name)
                select assembly.GetManifestResourceStream(resName)
                into stream
                select stream != null ? new StreamReader(stream) : null).FirstOrDefault();
        }
    }
}