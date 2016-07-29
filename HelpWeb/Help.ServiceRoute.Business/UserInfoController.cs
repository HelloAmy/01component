using Help.Common.Factory;
using Help.Common.Util;
using Help.Common.ViewModel;
using Help.DataService.VModel.AmyDB;
using Help.DataService.VModel.PagerService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Help.ServiceRoute.Business
{
    public class UserInfoController : Controller
    {
        /// <summary>
        /// dataServiceUrl
        /// </summary>
        private string dataServiceUrl = RouteFactory.APIAddress;

        public ActionResult UserInfoManage(int pageIndex = 1)
        {
            MPagerInParam param = new MPagerInParam()
            {
                DataBaseName = "AmyDBRead",
                FieldNames = "KeyID,LoginName,Password,UserName,Telephone,Email,ModifyTime,AddTime",
                PageIndex = pageIndex,
                Parameters = this.GetConditon(),
                PageSize = 20,
                TableName = "userinfo",
                Sort = "ModifyTime DESC"
            };

            string json = JsonConvert.SerializeObject(param);
            MPagerOutParam result = WebApiHelper.Get<MPagerOutParam>(this.dataServiceUrl + "/PagerService", "json=" + json);

            List<VMUserInfo> list = new List<VMUserInfo>();
            if (result != null && result.PageData != null && result.PageData.Rows.Count > 0)
            {
                foreach (DataRow row in result.PageData.Rows)
                {
                    VMUserInfo model = new VMUserInfo();
                    model.KeyID = row["KeyID"].ToString();
                    model.LoginName = row["LoginName"].ToString();
                    model.UserName = row["UserName"].ToString();
                    model.Password = row["Password"].ToString();
                    model.Telephone = row["Telephone"].ToString();
                    model.Email = row["Email"].ToString();
                    model.ModifyTime = Convert.ToDateTime(row["ModifyTime"].ToString());
                    model.AddTime = Convert.ToDateTime(row["AddTime"].ToString());

                    list.Add(model);
                }
            }

            PagedList<VMUserInfo> pagelist = new PagedList<VMUserInfo>(list, result.PageIndex, param.PageSize, (int)result.RowCount);

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
            if (this.Request.QueryString.Count == 0)
            {
                sqlparams.Add(new MSQLParameter("@UniqueSign", MySqlDbTypeDefine.VarChar) { Value = "GJ2014" });
                this.ViewData["UniqueSign"] = "GJ2014";

                sqlparams.Add(new MSQLParameter("@IsValid", MySqlDbTypeDefine.Int32) { Value = 1 });
                this.ViewData["IsValid"] = 1;
            }
            else
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString["ContractName"]))
                {
                    sqlparams.Add(new MSQLParameter("@ContractName", MySqlDbTypeDefine.VarChar) { Value = this.Request.QueryString["ContractName"] });
                }

                this.ViewData["ContractName"] = this.Request.QueryString["ContractName"];

                if (!string.IsNullOrEmpty(this.Request.QueryString["UniqueSign"]))
                {
                    sqlparams.Add(new MSQLParameter("@UniqueSign", MySqlDbTypeDefine.VarChar) { Value = this.Request.QueryString["UniqueSign"] });
                }

                this.ViewData["UniqueSign"] = this.Request.QueryString["UniqueSign"];

                if (!string.IsNullOrEmpty(this.Request.QueryString["IsValid"]))
                {
                    sqlparams.Add(new MSQLParameter("@IsValid", MySqlDbTypeDefine.Int32) { Value = Convert.ToInt32(this.Request.QueryString["IsValid"]) });
                    this.ViewData["IsValid"] = this.Request.QueryString["IsValid"];
                }
            }

            return sqlparams;
        }
    }
}
