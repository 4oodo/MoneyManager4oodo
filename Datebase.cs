using System.Data.SqlClient;

namespace MoneyManager4oodo
{
    public class Datebase
    {
        private SqlConnection sqlConnection = new SqlConnection(
            "@Data Source=jdbc:sqlite:MoneyManegerDB.sqlite");

        public void OpenConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }
    }
}