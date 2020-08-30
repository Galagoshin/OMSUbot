using System;

using System.IO;
using System.Data;
using Mono.Data.Sqlite;
using SqliteCommand = Microsoft.Data.Sqlite.SqliteCommand;
using SqliteConnection = Microsoft.Data.Sqlite.SqliteConnection;
using SqliteException = Microsoft.Data.Sqlite.SqliteException;

namespace OMSUbot
{
    public class DataBase
    {
        private String file;
        private SqliteConnection connection;
        private SqliteCommand sqlCmd;

        public DataBase(string filename)
        {
            connection = new SqliteConnection();
            sqlCmd = new SqliteCommand();
            file = filename;
            Init();
        }

        private void Init()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "./db.sqlite3";
            connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
            connection.Open();
        }
        
        public int QueryInt(string req)
        {
            var selectCmd = connection.CreateCommand();
            selectCmd.CommandText = req;
            int result = -0x1;
            using (var reader = selectCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }
            }

            return result;
        }

        public void Query(string req)
        {
            var selectCmd = connection.CreateCommand();
            selectCmd.CommandText = req;
            selectCmd.ExecuteReader();
        }
        
        public bool Exists(string req)
        {
            var selectCmd = connection.CreateCommand();
            selectCmd.CommandText = req;
            int result = -0x1;
            using (var reader = selectCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }
            }

            return result != -0x1;
        }

        public void Execute(string req)
        {
            var createTableCmd = connection.CreateCommand();
            createTableCmd.CommandText = req;
            createTableCmd.ExecuteNonQuery();
        }
    }
}