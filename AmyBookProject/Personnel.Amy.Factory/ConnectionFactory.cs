using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Personnel.Amy.Factory
{
    public class ConnectionFactory
    {
        public static IDbConnection AmyDBRead()
        {
            ConnectionStringSettings connectionSetting = ConfigurationManager.ConnectionStrings["AmyDBRead"];
            return new MySqlConnection(connectionSetting.ConnectionString);
        }

        public static IDbConnection AmyDBWrite()
        {
            ConnectionStringSettings connectionSetting = ConfigurationManager.ConnectionStrings["AmyDBWrite"];
            return new MySqlConnection(connectionSetting.ConnectionString);
        }
    }
}
