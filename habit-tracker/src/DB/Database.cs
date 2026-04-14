using Microsoft.Data.Sqlite;


namespace habit_tracker.src.DB;

public abstract class Database
{
    private readonly string _connectionString; 
    protected Database(string dbFilename)
    {
        _connectionString = $"Data Source=../../{dbFilename}";
        InitializeTable();
    }

    protected abstract void InitializeTable();

    protected List<T> ExecuteQuery<T>(string query, Func<SqliteDataReader, T> mapRow, Dictionary<string, object>? parameters = null)
    {
        var results = new List<T>();

        using var connection = new SqliteConnection(_connectionString);
        using var command = new SqliteCommand(query, connection);
        
        AddParameters(command, parameters);

        connection.Open();

        using var reader = command.ExecuteReader();
        
        while (reader.Read())
            results.Add(mapRow(reader));
        
        return results;
    }

    protected void ExecuteNonQuery(string query, Dictionary<string, object>? parameters = null)
    {
        using var connection = new SqliteConnection(_connectionString);
        using var command = new SqliteCommand(query, connection);

        AddParameters(command, parameters);

        connection.Open();
        command.ExecuteNonQuery();
    }

    protected bool RecordExists(string query, Dictionary<string, object>? parameters = null)
    {
        using var connection = new SqliteConnection(_connectionString);
        using var command = new SqliteCommand(query, connection);

        AddParameters(command, parameters);

        connection.Open();
        return Convert.ToInt32(command.ExecuteScalar()) > 0;
    }

    private void AddParameters(SqliteCommand command, Dictionary<string, object>? parameters = null)
    {
        if (parameters != null)
            foreach (var param in parameters)
                command.Parameters.AddWithValue(param.Key, param.Value);
    }

}