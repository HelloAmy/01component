using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Common.Factory
{
    public class ConnectionFactory
    {

        public static string UsermanagedbRead
        {
            get { return ConfigurationManager.ConnectionStrings["UsermanagedbRead"].ToString(); }
        }
    }
}
