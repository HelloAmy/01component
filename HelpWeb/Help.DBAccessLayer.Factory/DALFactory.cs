using Help.DBAccessLayer.DB2DAL;
using Help.DBAccessLayer.IDAL;
using Help.DBAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.DBAccessLayer.Factory
{
    public class DALFactory
    {
        public static IGetSchema GetSchemaDAO(MDataBaseType dbType, MDBAccessType accessType)
        {
            switch (dbType)
            {
                case MDataBaseType.DB2:
                    return new DGetSchema();
            }

            throw new Exception(string.Format("未实现的IGetSchema接口:数据库类型:{0},数据库访问类型:{1}", dbType.ToString(), accessType.ToString()));
        }
    }
}
