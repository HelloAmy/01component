using Help.Common.Service;
using Help.Common.Service.Service;
using Help.DBAccessLayer.Business;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TestMain
{
    class Program
    {
        static void Main(string[] args)
        {
            TestMySQLEF();
        }

        private static void TestMySQLEF()
        {
            StartUp.AutoMapperStart();
            Help.DBAccessLayer.Model.UsermanageDB.MRoleInfo model = new Help.DBAccessLayer.Model.UsermanageDB.MRoleInfo()
            {
                AddTime = DateTime.Now,
                IsDelete = 0,
                IsValid = 1,
                KeyID = string.Empty,
                ModifyTime = DateTime.Now,
                RoleAlias = "用户",
                RoleName = "普通用户",
            };

            Help.DBAccessLayer.Model.MOperateReturn ret = null;
            var service = Help.Common.Factory.ServiceFactory.GetUserManagerDataDAO();
            ret = service.AddRoleInfo(model);
        }

        private static void TestPagerQuery()
        {
            Help.DBAccessLayer.Model.PagerQueryModel.MPagerInParam para = new Help.DBAccessLayer.Model.PagerQueryModel.MPagerInParam()
            {
                DataBaseName = "UsermanagedbRead",
                FieldNames = "*",
                PageIndex = 1,
                Parameters = new List<System.Data.SqlClient.SqlParameter>(),
                Sort = string.Empty,
                TableName = "RoleInfo",
                DataBaseType = Help.DBAccessLayer.Model.MDataBaseType.MYSQL,
                Condition = string.Empty,
                PageSize = 20,
            };

            BPagerQuery bll = new BPagerQuery();
            var ret = bll.PagerQuery(para);
        }

        private static void TestExcel()
        {
            //获取文件信息
            //FileInfo fileInfo = new FileInfo(@"D:\09wirteable\Test.xlsx");
            ////获得该文件的访问权限
            //System.Security.AccessControl.FileSecurity fileSecurity = fileInfo.GetAccessControl();
            ////添加ereryone用户组的访问权限规则 完全控制权限
            //fileSecurity.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
            ////添加Users用户组的访问权限规则 完全控制权限
            //fileSecurity.AddAccessRule(new FileSystemAccessRule("Users", FileSystemRights.FullControl, AccessControlType.Allow));
            ////设置访问权限
            //fileInfo.SetAccessControl(fileSecurity);

            string connectionString = string.Format("Provider=Microsoft.Ace.OleDb.12.0;Data Source={0};Extended Properties='Excel 12.0; HDR=Yes; IMEX=3'", @"Test.xlsx");
            OleDbConnection connection = new OleDbConnection(connectionString);

            //打开连接
            if (connection.State == ConnectionState.Broken || connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = @"INSERT INTO [Sheet1$]
                            VALUES('2016/10/02')";

            OleDbCommand cmd = null;
            cmd = new OleDbCommand(sql, connection);

            cmd.ExecuteNonQuery();

            connection.Close();
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

        public static void TestGetSchema()
        {
            BGetSchema bll = new BGetSchema();
            var result = bll.GetTableList("TRSBANKUSR");
        }
    }
}
