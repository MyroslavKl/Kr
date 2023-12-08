using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxKr
{
    public class Execution
    {
        private readonly SqlConnection _connection;

        public Execution(SqlConnection connection)
        {
            this._connection = connection;
        }

        public void Add(int id, string name, int population) {
            SqlCommand cmd = new SqlCommand($"INSERT INTO City(Id,Name,Population) VALUES({id}, '{name}',{population})",_connection);
            _connection.Open();
            cmd.ExecuteNonQuery();
            _connection.Close();

        }
        public void Remove(int id)
        {
            SqlCommand cmd = new SqlCommand($"DELETE FROM City WHERE Id = {id}",_connection);
            _connection.Open();
            cmd.ExecuteNonQuery();
            _connection.Close();
        }

        public void Update(int population) {
            SqlCommand cmd = new SqlCommand($"UPDATE City SET Population = {population}", _connection);
            _connection.Open();
            cmd.ExecuteNonQuery();
            _connection.Close();
        }

        public void ReadAll() {
            SqlCommand cmd = new SqlCommand("SELECT * FROM City",_connection);
            _connection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader()) {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; ++i) {
                        Console.Write(reader.GetValue(i) + " ");
                    }
                    Console.WriteLine();
                }
            }
            _connection.Close();
        }

        public void Filter(int minPopulation,int maxPopulation) {
            SqlCommand cmd = new SqlCommand($"SELECT * FROM City WHERE Population>={minPopulation} AND Population<={maxPopulation}",_connection);
            _connection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader()) {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; ++i)
                    {
                        Console.Write(reader.GetValue(i) + " ");
                    }
                    Console.WriteLine();
                }
            }
                _connection.Close();
        }
    }
}
