// ***********************************************************************
// Assembly         : Help.ServiceRoute.Business
// Author           : zhujinrong
// Created          : 01-13-2016
//
// Last Modified By : zhujinrong
// Last Modified On : 07-11-2016
// ***********************************************************************
// <copyright file="ServiceRouteController.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using Help.Common.Factory;
using Help.Common.ViewModel;
using Help.DataService.VModel;
using Help.DataService.VModel.ServiceRouteDB;
using Newtonsoft.Json;
using Help.DBAccessLayer.Model.PagerQueryModel;
using System.Data.SqlClient;

namespace Help.ServiceRoute.Business
{
    /// <summary>
    /// ServiceRouteController
    /// </summary>
    public class ServiceRouteController : Controller
    {
        /// <summary>
        /// dataServiceUrl
        /// </summary>
        private string dataServiceUrl = RouteFactory.APIAddress;

        /// <summary>
        /// Pager
        /// </summary>
        /// <param name="pageIndex">pageIndex</param>
        /// <returns>结果</returns>
        public ActionResult Pager(int pageIndex = 1)
        {
            MPagerInParam param = new MPagerInParam()
            {
                DataBaseName = "ServiceRouteDBRead",
                FieldNames = "RouteID,ContractName,ServiceType,CallSystem,MachineNO,DataCenter,UniqueSign,BindingType,ServiceIP,ServicePort,SvcPath,IsValid,ModifyTime,IsDelete,IsVirtualAddress,ProgramName",
                PageIndex = pageIndex,
                Parameters = this.GetConditon(),
                PageSize = 20,
                TableName = "ServiceRoute",
                Sort = "ModifyTime DESC"
            };

            MPagerReturn result = ServiceFactory.GetPagerContractDAO().PagerQuery(param);

            List<VMServiceRoute> list = new List<VMServiceRoute>();
            if (result != null && result.PageData != null && result.PageData.Rows.Count > 0)
            {
                foreach (DataRow row in result.PageData.Rows)
                {
                    VMServiceRoute model = new VMServiceRoute();
                    model.RouteID = row["RouteID"].ToString();
                    model.ContractName = row["ContractName"].ToString();
                    model.ServiceType = row["ServiceType"].ToString();
                    model.CallSystem = row["CallSystem"].ToString();
                    model.MachineNO = row["MachineNO"].ToString();
                    model.DataCenter = row["DataCenter"].ToString();
                    model.UniqueSign = row["UniqueSign"].ToString();
                    model.BindingType = row["BindingType"].ToString();
                    model.ServiceIP = row["ServiceIP"].ToString();
                    model.ServicePort = Convert.ToInt32(row["ServicePort"].ToString());
                    model.SvcPath = row["SvcPath"].ToString();
                    model.IsValid = Convert.ToInt32(row["IsValid"].ToString());
                    model.ModifyTime = Convert.ToDateTime(row["ModifyTime"].ToString());
                    model.IsDelete = Convert.ToInt32(row["IsDelete"].ToString());
                    model.IsVirtualAddress = Convert.ToInt32(row["IsVirtualAddress"].ToString());
                    model.ProgramName = row["ProgramName"].ToString();
                    list.Add(model);
                }
            }

            PagedList<VMServiceRoute> pagelist = new PagedList<VMServiceRoute>(list, result.PageIndex, param.PageSize, (int)result.RowCount);

            return this.View(pagelist);
        }

        ///// <summary>
        ///// GetServiceRoute
        ///// </summary>
        ///// <param name="routeid">routeid</param>
        ///// <returns>结果</returns>
        //public JsonResult GetServiceRoute(string routeid)
        //{
        //    var requestJson = JsonConvert.SerializeObject(new { routeid = routeid });
        //    Dictionary<string, string> dic = new Dictionary<string, string>();
        //    dic.Add("routeid", routeid);
        //    string ret = WebApiHelper.Get("http://localhost:6293/api/ServiceRoute", dic);
        //    return this.Json(new { Result = ret });
        //}

        ///// <summary>
        ///// UpdateServiceRoute
        ///// </summary>
        ///// <param name="jsonStr">jsonStr</param>
        ///// <returns>结果</returns>
        //public JsonResult Save(string jsonStr)
        //{
        //    VMResult ret = WebApiHelper.Post<VMResult>(this.dataServiceUrl + "/ServiceRoute/Patch", jsonStr);
        //    return this.Json(ret);
        //}

        /// <summary>
        /// GetConditon
        /// </summary>
        /// <returns>结果</returns>
        List<SqlParameter> GetConditon()
        {
            List<SqlParameter> sqlparams = new List<SqlParameter>();
            sqlparams.Add(new SqlParameter("@IsDelete", SqlDbType.Int) { Value = 0 });
            if (this.Request.QueryString.Count == 0)
            {
                sqlparams.Add(new SqlParameter("@UniqueSign", SqlDbType.VarChar) { Value = "GJ2014" });
                this.ViewData["UniqueSign"] = "GJ2014";

                sqlparams.Add(new SqlParameter("@IsValid", SqlDbType.Int) { Value = 1 });
                this.ViewData["IsValid"] = 1;
            }
            else
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString["ContractName"]))
                {
                    sqlparams.Add(new SqlParameter("@ContractName", SqlDbType.VarChar) { Value = this.Request.QueryString["ContractName"] });
                }

                this.ViewData["ContractName"] = this.Request.QueryString["ContractName"];

                if (!string.IsNullOrEmpty(this.Request.QueryString["UniqueSign"]))
                {
                    sqlparams.Add(new SqlParameter("@UniqueSign", SqlDbType.VarChar) { Value = this.Request.QueryString["UniqueSign"] });
                }

                this.ViewData["UniqueSign"] = this.Request.QueryString["UniqueSign"];

                if (!string.IsNullOrEmpty(this.Request.QueryString["IsValid"]))
                {
                    sqlparams.Add(new SqlParameter("@IsValid", SqlDbType.Int) { Value = Convert.ToInt32(this.Request.QueryString["IsValid"]) });
                    this.ViewData["IsValid"] = this.Request.QueryString["IsValid"];
                }
            }

            return sqlparams;
        }

        /// <summary>
        /// GetPagerResultByWebAPI
        /// </summary>
        /// <param name="param">param</param>
        /// <returns>结果</returns>
        //private MPagerOutParam GetPagerResultByWebAPI(MPagerInParam param)
        //{
        //    string json = JsonConvert.SerializeObject(param);
        //    MPagerOutParam result = WebApiHelper.Get<MPagerOutParam>(this.dataServiceUrl + "/PagerService", "json=" + json);
        //    return result;
        //}
    }
}
