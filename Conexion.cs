using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fury_Software
{
    public static class Conexion
    {
        private static string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", "furysoftware.accdb");
        private static string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};Persist Security Info=False;";

        public static OleDbConnection Conectar()
        {
            return new OleDbConnection(connectionString);
        }
    }
}
