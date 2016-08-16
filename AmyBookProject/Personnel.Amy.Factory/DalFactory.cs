using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personnel.Amy.IDAO;
using Personnel.Amy.MYSQL;

namespace Personnel.Amy.Factory
{
    public class DalFactory
    {
        public static IBook GetBookDao()
        {
            return new DBook();
        }
    }
}
