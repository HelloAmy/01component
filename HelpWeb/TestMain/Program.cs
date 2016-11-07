using Help.Common.Util;
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
            TestReadExcel();
        }

        private static void TestReadExcel()
        {
            string path = @"D:\01code\02mine\01component\HelpWeb\HelpWeb\Upload\UserManageDB.xls";
            DataSet ds = ExcelUtil.GetExcelDataSet(path);
        }
    }
}
