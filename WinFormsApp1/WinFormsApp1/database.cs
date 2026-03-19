using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class database
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3307;username=root;password=1234;database=restaurant");

        public void openConnection()
        {
            connection.Open();
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public MySqlConnection getConnection()
        {
            return connection;
        }

        public DataTable ExecuteQuery(string sql)
        {
            try
            {
                openConnection();
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                closeConnection();
                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка запроса: {ex.Message}");
                return null;
            }
        }

        public int ExecuteNonQuery(string sql)
        {
            try
            {
                openConnection();
                MySqlCommand command = new MySqlCommand(sql, connection);
                int rows = command.ExecuteNonQuery();
                closeConnection();
                return rows;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка выполнения: {ex.Message}");
                return -1;
            }
        }
    }
}
