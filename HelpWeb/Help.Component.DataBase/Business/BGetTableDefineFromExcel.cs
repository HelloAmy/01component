using Help.Common.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Component.DataBase
{
    public class BGetTableDefineFromExcel
    {
        public List<MTableDefine> GetTableDefineListFromExcel(string path)
        {
            DataSet ds = ExcelUtil.GetExcelDataSet(path);
            var ret = this.GetTableDefineList(ds);
            return ret;
        }

        private List<MTableDefine> GetTableDefineList(DataSet ds)
        {
            List<MTableDefine> tb = new List<MTableDefine>();

            foreach (DataTable item in ds.Tables)
            {
                var ret = getTableDefine(item);
                if (ret != null)
                {
                    tb.Add(ret);
                }

            }

            return tb;
        }

        private MTableDefine GetTableDefine(DataTable tb)
        {
            MTableDefine ret = new MTableDefine();

            if (tb == null)
            {
                return null;
            }

            if (tb.TableName.Contains("首页") || tb.TableName.Contains("数据表一栏"))
            {
                return null;
            }

            // 估计带超链接，还真不准，先注释掉
            //if (tb.Rows[0][0].ToString() != "返回一览表")
            //{
            //    return null;
            //}

            if (tb.Rows[1][0].ToString() != "TableName")
            {
                return null;
            }

            ret.TableName = tb.Rows[2][0].ToString();
            ret.TableNameCH = tb.Rows[2][1].ToString();
            ret.TableDescrption = tb.Rows[2][2].ToString();
            ret.FieldList = new List<MFieldDefine>();
            for (int i = 5; i < tb.Rows.Count; i++)
            {
                MFieldDefine col = new MFieldDefine();
                col.FieldNameCH = tb.Rows[i][1].ToString();
                col.FieldName = tb.Rows[i][2].ToString();
                col.DataType = tb.Rows[i][3].ToString();

                string tempstr = tb.Rows[i][4].ToString();
                int tempint = 0;
                if (!string.IsNullOrEmpty(tempstr) && int.TryParse(tempstr, out tempint))
                {
                    col.Length = tempint;
                }

                tempstr = tb.Rows[i][5].ToString();
                if (!string.IsNullOrEmpty(tempstr) && tempstr == "○")
                {
                    col.IsNullable = false;
                }

                tempstr = tb.Rows[i][6].ToString();

                if (!string.IsNullOrEmpty(tempstr) && int.TryParse(tempstr, out tempint))
                {
                    col.PrimaryKeyIndex = tempint;
                }

                col.ForeignRelation = tb.Rows[i][7].ToString();

                tempstr = tb.Rows[i][7].ToString();
                if (!string.IsNullOrEmpty(tempstr) && tempstr == "○")
                {
                    col.IsUniqueIndex = true;
                }

                tempstr = tb.Rows[i][8].ToString();
                if (!string.IsNullOrEmpty(tempstr) && int.TryParse(tempstr, out tempint))
                {
                    col.IndexNo = tempint;
                }

                tempstr = tb.Rows[i][9].ToString();
                if (!string.IsNullOrEmpty(tempstr) && tempstr == "○")
                {
                    col.IsAutoIncrement = true;
                }

                col.FieldFormat = tb.Rows[i][10].ToString();
                col.DefaultValue = tb.Rows[i][11].ToString();
                col.ValueConstraint = tb.Rows[i][12].ToString();
                col.ProjectSignificance = tb.Rows[i][13].ToString();
                ret.FieldList.Add(col);
            }

            return ret;
        }
    }
}
