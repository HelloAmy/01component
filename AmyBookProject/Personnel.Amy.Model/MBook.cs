// ***********************************************************************
// Assembly         : Personnel.Amy.Model
// Author           : Amy
// Created          : 02-22-2014
//
// Last Modified By : Amy
// Last Modified On : 02-22-2014
// ***********************************************************************
// <copyright file="MBook.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace Personnel.Amy.Model
{
    public class MBook
    {
        #region private members

        /// <summary>
        ///  主键ID
        /// </summary>
        private string keyID = string.Empty;

        /// <summary>
        ///  书名
        /// </summary>
        private string name = string.Empty;

        /// <summary>
        ///  作者
        /// </summary>
        private string author = string.Empty;

        /// <summary>
        ///  出版社
        /// </summary>
        private int press;

        /// <summary>
        ///  出版日期
        /// </summary>
        private DateTime pressDateTime;

        /// <summary>
        ///  是否已读
        /// </summary>
        private int isread;

        /// <summary>
        ///  是否删除
        /// </summary>
        private int isdelete;

        #endregion

        #region construction

        /// <summary>
        /// 构造函数
        /// </summary>
        public MBook()
        {
        }

        #endregion

        #region public members

        /// <summary>
        /// 主键ID
        /// </summary>
        public string KeyID
        {
            get { return this.keyID; }
            set { this.keyID = value; }
        }

        /// <summary>
        /// 书名
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author
        {
            get { return this.author; }
            set { this.author = value; }
        }

        /// <summary>
        /// 出版社
        /// </summary>
        public int Press
        {
            get { return this.press; }
            set { this.press = value; }
        }

        /// <summary>
        /// 出版日期
        /// </summary>
        public DateTime PressDateTime
        {
            get { return this.pressDateTime; }
            set { this.pressDateTime = value; }
        }

        /// <summary>
        /// 是否已读
        /// </summary>
        public int IsRead
        {
            get { return this.isread; }
            set { this.isread = value; }
        }

        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDelete
        {
            get { return this.isdelete; }
            set { this.isdelete = value; }
        }

        #endregion
    }
}
