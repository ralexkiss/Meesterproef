using MySql.Data.MySqlClient;

namespace Data
{
    public static class DataConnection
    {
        private static readonly string ConnectionString = new MySqlConnectionStringBuilder
        {
            Server = "78.47.226.85",
            Port = 3306,
            Database = "s14_meesterproef_alex",
            UserID = "u14_2EKb0AyTcQ",
            Password = "QmR@=gRwucyMpuoSanFc7oa5"
        }.ConnectionString;

        public static MySqlConnection getConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}