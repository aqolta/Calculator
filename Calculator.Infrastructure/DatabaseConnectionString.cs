namespace Calculator.Infrastructure
{
    public class DatabaseConnectionString : IDatabaseReadOnlyConnectionString
    {
        public DatabaseConnectionString(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public string ConnectionString { get; }
    }
}
