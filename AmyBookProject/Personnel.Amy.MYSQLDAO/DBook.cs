using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personnel.Amy.Model;
using Personnel.Amy.IDAO;
using MySql.Data.MySqlClient;
using Better.Infrastructures.DBUtility;
using System.Data;

namespace Personnel.Amy.MYSQL
{
    public class DBook : IBook
    {
        public bool AddBook(System.Data.IDbTransaction trans, System.Data.IDbConnection conn, MBook model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" INSERT INTO Book(KeyID, Name, Author, Press, PressDateTime, IsRead)");
            sql.Append(" SELECT @KeyID, @Name, @Author, @Press, @PressDateTime, @IsRead");
            sql.Append(" FROM DUAL");
            sql.Append(" WHERE NOT EXISTS(");
            sql.Append(" SELECT *");
            sql.Append(" FROM Book");
            sql.Append(" WHERE Name = @Name");
            sql.Append(" AND Author = @Author");
            sql.Append(" AND Press = @Press");
            sql.Append(" )");
            MySqlParameter[] para = new MySqlParameter[]
            {
                new MySqlParameter("@KeyID", model.KeyID),
                new MySqlParameter("@Name", MySqlDbType.VarChar){ Value = model.Name },
                new MySqlParameter("@Author", model.Author),
                new MySqlParameter("@Press", model.Press),
                new MySqlParameter("@PressDateTime", model.PressDateTime),
                new MySqlParameter("@IsRead", model.IsRead)
            };

            
            return MysqlHelper.ExecuteSql(trans, conn, sql.ToString(), para) >= 1 ? true : false;
        }

        public bool DelBook(System.Data.IDbTransaction trans, System.Data.IDbConnection conn, string keyID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" UPDATE Book");
            sql.Append(" SET isDelete = 1");
            sql.Append(" WHERE KeyID = @KeyID");
            MySqlParameter[] para = new MySqlParameter[]
            {
                new MySqlParameter("@KeyID", keyID),
            };

            return false;
        }

        public bool GetBookByKeyID(System.Data.IDbTransaction trans, System.Data.IDbConnection conn, string keyID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBook(System.Data.IDbTransaction trans, System.Data.IDbConnection conn, MBook model)
        {
            throw new NotImplementedException();
        }
    }
}
