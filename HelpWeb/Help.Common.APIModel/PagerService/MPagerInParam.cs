using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Help.Common.APIModel.PagerService
{
    /// <summary>
    /// 查询参数的入参
    /// </summary>
    public class MPagerInParam
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public MPagerInParam()
        {
            this.PageIndex = 0;
            this.PageSize = 0;
            this.DataBaseName = string.Empty;
            this.TableName = string.Empty;
            this.FieldNames = string.Empty;
            this.Sort = string.Empty;
            this.Parameters = new List<MSQLParameter>();
        }

        /// <summary>
        /// 页数
        /// </summary>
        public int PageIndex
        {
            get;
            set;
        }

        public int PageSize
        {
            get;
            set;
        }

        /// <summary>
        /// 数据库名
        /// </summary>
        public string DataBaseName
        {
            get;
            set;
        }

        /// <summary>
        /// 表名
        /// </summary>
        public string TableName
        {
            get;
            set;
        }

        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldNames
        {
            get;
            set;
        }

        /// <summary>
        /// 条件
        /// </summary>
        public string Sort
        {
            get;
            set;
        }

        /// <summary>
        /// 查询参数
        /// </summary>
        public List<MSQLParameter> Parameters
        {
            get;
            set;
        }

        /// <summary>
        /// 拷贝函数
        /// </summary>
        /// <returns>返回</returns>
        public MPagerInParam Copy()
        {
            MPagerInParam copy = new MPagerInParam()
            {
                Parameters = this.Parameters,
                Sort = this.Sort,
                DataBaseName = this.DataBaseName,
                FieldNames = this.FieldNames,
                TableName = this.TableName,
            };

            return copy;
        }
    }
}
