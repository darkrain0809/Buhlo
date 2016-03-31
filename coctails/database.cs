using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace coctails
{
    class DB
    {
        static string connectionString = "Server=localhost;" +
                    "Database=dbcoctails;" +
                    "Uid=root;" +
                    "Pwd=1234;";
        public static DataTable Query (String q1) //select
        {
            MySqlConnection connection = new MySqlConnection(connectionString);//подключение к бд
            MySqlCommand cmd = new MySqlCommand(q1, connection);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(q1, connection);
            dataAdapter.SelectCommand = new MySqlCommand(q1, connection);    
            DataTable dTable = new DataTable(); //заполнение таблицы
            dataAdapter.Fill(dTable);
            return dTable;
        }
        public static DataTable Query(String q1, DataTable dTable) //select уже в готовую таблицу
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(q1, connection);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(q1, connection);
            dataAdapter.SelectCommand = new MySqlCommand(q1, connection);
            dataAdapter.Fill(dTable);
            return dTable;
        }
        public static void Query1(String q1)//update delete insert
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(q1, connection);
            MySqlDataReader MyReader2;
            connection.Open();
            MyReader2 = cmd.ExecuteReader();
            connection.Close(); 
    }
    }
}

