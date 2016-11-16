using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Component.DataBase
{
    public class DALFactory
    {
        public static IGenerator GetGeneratorSQLDAL(MDataBaseType type)
        {
            switch (type)
            {
                case MDataBaseType.MySQL:
                    return new MySQLGeneratoDAO();

                default:
                    throw new Exception(string.Format("数据库类型:{0},并没有实现", type.ToString()));
            }
        }
    }
}
