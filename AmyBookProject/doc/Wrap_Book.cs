        #region model read

        //  主键ID
        model.KeyID = Convert.ToString(reader["KeyID"] == DBNull.Value ? string.Empty : reader["KeyID"]);
        //  书名
        model.Name = Convert.ToString(reader["Name"] == DBNull.Value ? string.Empty : reader["Name"]);
        //  作者
        model.Author = Convert.ToString(reader["Author"] == DBNull.Value ? string.Empty : reader["Author"]);
        //  出版社
        model.Press = Convert.ToInt32(reader["Press"] == DBNull.Value ? 0 : reader["Press"]);
        //  出版日期
        model.PressDateTime = Convert.ToDateTime(reader["PressDateTime"] == DBNull.Value ? DateTime.Parse("1900-01-01") : reader["PressDateTime"]);
        //  是否已读
        model.IsRead = Convert.ToInt32(reader["IsRead"] == DBNull.Value ? 0 : reader["IsRead"]);
        //  是否删除
        model.IsDelete = Convert.ToInt32(reader["IsDelete"] == DBNull.Value ? 0 : reader["IsDelete"]);
        //  时间戳
        model.ModifyTime = Convert.ToString(reader["ModifyTime"] == DBNull.Value ? string.Empty : reader["ModifyTime"]);

        #endregion
