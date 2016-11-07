using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Common.Util
{
    public class ExcelUtil
    {
        public static DataSet GetExcelDataSet(string strExcelPath)
        {
            //数据表
            DataSet ds = new DataSet();
            //获取文件扩展名
            string strExtension = System.IO.Path.GetExtension(strExcelPath);
            string strFileName = System.IO.Path.GetFileName(strExcelPath);
            // Excel的连接
            OleDbConnection objConn = null;
            switch (strExtension)
            {
                case ".xls":
                    objConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strExcelPath + ";" + "Extended Properties=\"Excel 8.0;HDR=NO;IMEX=1;\"");
                    break;
                case ".xlsx":
                    objConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strExcelPath + ";" + "Extended Properties=\"Excel 12.0;HDR=NO;IMEX=1;\"");
                    break;
                default:
                    objConn = null;
                    break;
            }

            if (objConn == null)
            {
                return null;
            }

            objConn.Open();

            // 返回Excel的架构，包括各个sheet表的名称,类型，创建时间和修改时间等    
            DataTable dtSheetName = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });

            List<string> sheetList = GetTableNameList(dtSheetName);

            foreach (var item in sheetList)
            {
                string strSql = "select * from [" + item + "]";

                // 获取Excel指定Sheet表中的信息
                OleDbCommand objCmd = new OleDbCommand(strSql, objConn);
                OleDbDataAdapter myData = new OleDbDataAdapter(strSql, objConn);

                // 填充数据
                myData.Fill(ds, item);
            }

            objConn.Close();

            return ds;
        }

        private static List<string> GetTableNameList(DataTable dtSheetName)
        {
            string[] strTableNames = new string[dtSheetName.Rows.Count];
            for (int k = 0; k < dtSheetName.Rows.Count; k++)
            {
                strTableNames[k] = dtSheetName.Rows[k]["TABLE_NAME"].ToString();
            }

            return strTableNames.ToList();
        }

    }
}
