using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Component.DataBase
{
    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum MDataBaseType
    {
        /// <summary>
        /// 未知数据库名
        /// </summary>
        UNKNOW = 0,

        /// <summary>
        /// MySQL数据库
        /// </summary>
        MySQL = 1,

        /// <summary>
        /// SQLSERVER
        /// </summary>
        SQLSERVER = 2,
    }
}
