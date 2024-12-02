using System.Data.SqlClient;
using System.Windows;

namespace OrderQuanNet.Services
{
    internal class Database<T> where T : class
    {
        private static readonly string _connectionString = "Server=localhost;Database=OrderQuanNet;Trusted_Connection=True;";
        private readonly string _tableName;

        public Database(string tableName)
        {
            _tableName = tableName;
        }

        public bool Insert(T item)
        {
            var columns = string.Join(", ", GetColumns(item, false, true));
            var parameters = string.Join(", ", GetColumns(item, true, true));
            var query = $"INSERT INTO {_tableName} ({columns}) VALUES ({parameters})";

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    AddParameters(command, item);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Update(T item)
        {
            var setClause = string.Join(", ", CreateParameters(item, true, true));
            var query = $"UPDATE {_tableName} SET {setClause} WHERE id = @id";

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    AddParameters(command, item);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(T item)
        {
            var query = $"DELETE FROM {_tableName} WHERE id = @id";

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    AddParameters(command, item);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public SqlDataReader Select(T item, bool selectWithAllNullItem = false)
        {
            var connection = new SqlConnection(_connectionString);
            var parameters = selectWithAllNullItem ? string.Join(" AND ", CreateParameters(item, true, true)) : string.Join(" AND ", CreateParametersNotNull(item, true, true));
            var query = $"SELECT * FROM {_tableName} WHERE {parameters}";

            var command = new SqlCommand(query, connection);
            AddParameters(command, item);

            command.CommandText = query;
            connection.Open();

            return command.ExecuteReader();
        }

        public SqlDataReader SelectById(int id)
        {
            var query = $"SELECT * FROM {_tableName} WHERE id = @id";

            var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();

            return command.ExecuteReader();
        }

        public SqlDataReader SelectAll()
        {
            var query = $"SELECT * FROM {_tableName}";

            var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand(query, connection);
            connection.Open();

            return command.ExecuteReader();
        }

        private IEnumerable<string> CreateParameters(T item, bool isParameter = false, bool excludeId = false)
        {
            foreach (var property in item.GetType().GetProperties())
            {
                if (excludeId && property.Name == "id") continue;
                yield return isParameter ?
                    (property.GetValue(item) == null ? $"{property.Name} IS NULL" : $"{property.Name} = @{property.Name}")
                    : property.Name;
            }
        }

        private IEnumerable<string> CreateParametersNotNull(T item, bool isParameter = false, bool excludeId = false)
        {
            foreach (var property in item.GetType().GetProperties())
            {
                if (excludeId && property.Name == "id") continue;
                if (property.GetValue(item) == null) continue;
                yield return isParameter ? $"{property.Name} = @{property.Name}" : property.Name;
            }
        }

        private void AddParameters(SqlCommand command, T item)
        {
            foreach (var property in item.GetType().GetProperties())
            {
                command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(item) ?? DBNull.Value);
            }
        }

        private IEnumerable<string> GetColumns(T item, bool isParameter = false, bool excludeId = false)
        {
            foreach (var property in item.GetType().GetProperties())
            {
                if (excludeId && property.Name == "id") continue;
                if (property.GetValue(item) == null) continue;
                yield return isParameter ? $"@{property.Name}" : property.Name;
            }
        }
    }
}
