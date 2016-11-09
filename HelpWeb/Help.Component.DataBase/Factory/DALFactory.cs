using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Component.DataBase
{
    public class DALFactory
    {
        public static IGeneratorSQL GetGeneratorSQLDAL(MDataBaseType type)
        {
            switch (type)
            {
                case MDataBaseType.MySQL:
                    return new MySQLGeneratorSQLDAO();

                default:
                    throw new Exception(string.Format("数据库类型:{0},并没有实现", type.ToString()));
            }
        }
    }
}
