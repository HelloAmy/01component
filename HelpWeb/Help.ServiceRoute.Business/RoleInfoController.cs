// ***********************************************************************
// Assembly         : Help.ServiceRoute.Business
// Author           : zhujinrong
// Created          : 07-11-2016
//
// Last Modified By : zhujinrong
// Last Modified On : 07-11-2016
// ***********************************************************************
// <copyright file="RoleInfoController.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using Help.Common.Factory;
using Help.Common.Util;
using Help.Common.ViewModel;
using Help.DataService.VModel;
using Help.DataService.VModel.AmyDB;
using Help.DataService.VModel.PagerService;
using Newtonsoft.Json;

namespace Help.ServiceRoute.Business
{
    /// <summary>
    /// RoleInfoController
    /// </summary>
    public class RoleInfoController : Controller
    {
        /// <summary>
        /// dataServiceUrl
        /// </summary>
        private string dataServiceUrl = RouteFactory.APIAddress;

        /// <summary>
        /// Index
        /// </summary>
        /// <param name="pageIndex">pageIndex</param>
        /// <returns>结果</returns>
        public ActionResult Index(int pageIndex = 1)
        {
            MPagerInParam param = new MPagerInParam()
            {
                DataBaseName = "AmyDBRead",
                FieldNames = "KeyID, RoleName,RoleAlias, ModifyTime,AddTime,IsValid,IsDelete",
                PageIndex = pageIndex,
                Parameters = this.GetConditon(),
                PageSize = 20,
                TableName = "RoleInfo",
                Sort = "ModifyTime DESC"
            };

            string json = JsonConvert.SerializeObject(param);
            MPagerOutParam result = WebApiHelper.Get<MPagerOutParam>(this.dataServiceUrl + "/PagerService", "json=" + json);

            List<VMRoleInfo> list = new List<VMRoleInfo>();
            if (result != null && result.PageData != null && result.PageData.Rows.Count > 0)
            {
                foreach (DataRow row in result.PageData.Rows)
                {
                    VMRoleInfo model = new VMRoleInfo();
                    model.KeyID = row["KeyID"].ToString();
                    model.RoleName = row["RoleName"].ToString();
                    model.IsValid = Convert.ToInt32(row["IsValid"].ToString());
                    model.ModifyTime = Convert.ToDateTime(row["ModifyTime"].ToString());
                    model.AddTime = Convert.ToDateTime(row["AddTime"].ToString());
                    model.IsDelete = Convert.ToInt32(row["IsDelete"].ToString());
                    model.RoleAlias = row["RoleAlias"].ToString();

                    list.Add(model);
                }
            }

            PagedList<VMRoleInfo> pagelist = new PagedList<VMRoleInfo>(list, result.PageIndex, param.PageSize, (int)result.RowCount);

            return this.View(pagelist);
        }

        /// <summary>
        /// GetConditon
        /// </summary>
        /// <returns>结果</returns>
        List<MSQLParameter> GetConditon()
        {
            List<MSQLParameter> sqlparams = new List<MSQLParameter>();
            sqlparams.Add(new MSQLParameter("@IsDelete", MySqlDbTypeDefine.Int32) { Value = 0 });
            if (this.Request.QueryString.Count > 0)
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString["RoleName"]))
                {
                    sqlparams.Add(new MSQLParameter("@RoleName", MySqlDbTypeDefine.VarChar) { Value = this.Request.QueryString["RoleName"] });
                    this.ViewData["RoleName"] = this.Request.QueryString["RoleName"];
                }

                if (!string.IsNullOrEmpty(this.Request.QueryString["IsValid"]))
                {
                    sqlparams.Add(new MSQLParameter("@IsValid", MySqlDbTypeDefine.Int32) { Value = Convert.ToInt32(this.Request.QueryString["IsValid"]) });
                    this.ViewData["IsValid"] = this.Request.QueryString["IsValid"];
                }
            }

            return sqlparams;
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="json">json</param>
        /// <returns>结果</returns>
        public JsonResult Save(string json)
        {
            VMResult ret = WebApiHelper.Post<VMResult>(this.dataServiceUrl + "/RoleInfo", json);

            return this.Json(ret);
        }

        public JsonResult Get(string keyid)
        {
            try
            {
                VMRoleInfo ret = WebApiHelper.Get<VMRoleInfo>(this.dataServiceUrl + "/RoleInfo", "keyid=" + keyid);

                return this.Json(new { IsSuccess = true, Result = ret });
            }
            catch (Exception ex)
            {
                return this.Json(new { IsSuccess = false, ErrorMsg = ex.Message.ToString() });
            }

        }

        public JsonResult Get()
        {
            try
            {
                List<VMRoleInfo> ret = WebApiHelper.Get<List<VMRoleInfo>>(this.dataServiceUrl + "/RoleInfo", string.Empty);

                return this.Json(new { IsSuccess = true, Result = ret });
            }
            catch (Exception ex)
            {
                return this.Json(new { IsSuccess = false, ErrorMsg = ex.Message.ToString() });
            }
        }
    }
}
