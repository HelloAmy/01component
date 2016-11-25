using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.DBAccessLayer.Factory
{
    public class ConnectionFactory
    {
        public static string TRSDbConnString
        {
            get { return ConfigurationManager.ConnectionStrings["TRSDbServer"].ToString(); }
        }


    }
}
