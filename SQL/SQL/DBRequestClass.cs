using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Data.SqlTypes;
using System.Linq;
using System.Security;
using System.Threading;

namespace SQLHW
{
    public class DBRequestClass
    {
        public static SQLiteConnection DBConnect(string path)
        {
            String connectToDB = @path;           
            SQLiteConnection database = new SQLiteConnection(connectToDB);
            database.Open();
            return database;
        }

        public static SQLiteCommand CommandToDB(string command, SQLiteConnection database)
        {
            SQLiteCommand cmd = database.CreateCommand();
            cmd.CommandText = command;

            return cmd;

        }

        public static void CloseConnection(SQLiteConnection database)
        {
            database.Close();
        }
    }
}
