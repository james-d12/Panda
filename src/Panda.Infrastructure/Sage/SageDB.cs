using Microsoft.Data.SqlClient;

namespace Panda.Infrastructure.Sage;
internal static class SageDB
{
    public static List<T> ReadDataFromDatabase<T>(string sqlQuery, Func<SqlDataReader, T> mapper, SqlParameter[]? parameters = null)
    {
        SqlConnectionStringBuilder builder = new()
        {
            DataSource = "DCR-SVR-SQL01-V\\SAGEFINANCE",
            UserID = "ig_sql.sage200",
            Password = "r=fM6eBD2M#?C*hQ",
            InitialCatalog = "ScottBrownriggLtd",
            TrustServerCertificate = true,
            Encrypt = false,
            ConnectTimeout = 10,
        };

        var result = new List<T>();
        using (var connection = new SqlConnection(builder.ConnectionString))
        {
            var command = new SqlCommand(sqlQuery, connection);

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            connection.Open();

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var mappedObject = mapper(reader);
                result.Add(mappedObject);
            }
            connection.Close();
        }
        return result;
    }

}
