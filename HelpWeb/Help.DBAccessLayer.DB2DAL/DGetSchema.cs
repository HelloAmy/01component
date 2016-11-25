using Help.DBAccessLayer.IDAL;
using Help.DBAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.DBAccessLayer.DB2DAL
{
    public class DGetSchema : IGetSchema
    {
        public List<MTableDesc> GetTableList(IDbConnection conn, string creater)
        {
            string strSql = @"select NAME, CREATOR,CTIME,REMARKS from sysibm.systables where type='T' ";

            if (!string.IsNullOrEmpty(creater))
            {
                strSql += string.Format("and creator='{0}'", creater);
            }

            OleDbCommand cmd = new OleDbCommand(strSql, (OleDbConnection)conn);

            List<MTableDesc> ret = new List<MTableDesc>();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    MTableDesc model = new MTableDesc();
                    model.TableName = reader["NAME"] == DBNull.Value ? string.Empty : reader["NAME"].ToString();
                    model.Creator = reader["CREATOR"] == DBNull.Value ? string.Empty : reader["CREATOR"].ToString();
                    model.CreateDateTime = reader["CTIME"] == DBNull.Value ? DateTime.Parse("1990-01-01") : Convert.ToDateTime(reader["CTIME"].ToString());
                    model.Remarks = reader["REMARKS"] == DBNull.Value ? string.Empty : reader["REMARKS"].ToString();

                    ret.Add(model);
                }
            }


            return ret;
        }
    }
}
