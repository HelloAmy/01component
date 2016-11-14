using Help.Common.Util;
using Help.Component.DataBase;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMain
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSQL();
        }

        public static void TestSQL()
        {
            BGetTableDefineFromExcel bll = new BGetTableDefineFromExcel();
            var db = bll.GetTableDefineListFromExcel(@"D:\01code\02mine\01component\HelpWeb\HelpWeb\Upload\UserManageDB.xls");

            string json = JsonConvert.SerializeObject(db);
            BGeneratorSQL sqlBll = new BGeneratorSQL();
            var ret = sqlBll.GeneratorSQL(db);
            string jsonRet = JsonConvert.SerializeObject(ret);
        }

    }
}
