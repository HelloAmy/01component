using Help.DBAccessLayer.Business;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Help.ServiceRoute.Business
{
    public class DBCreaterController : Controller
    {
        public ActionResult SQLGenerator()
        {
            return this.View();
        }

        public ActionResult ShowDataBaseInfo()
        {
            return this.View();
        }

        public JsonResult ImportExcelFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength == 0)
                {
                    return this.Json(new { IsSuccess = false, ErrorMsg = "没有文件！" });
                }

                // 生成文件名
                var fileName = Path.Combine(Request.MapPath("~/Upload/" + DateTime.Now.ToString("yyyyMM")), Guid.NewGuid().ToString().ToUpper() + Path.GetFileName(file.FileName));

                // 按月存储文件
                if (Directory.Exists(Request.MapPath("~/Upload/" + DateTime.Now.ToString("yyyyMM"))) == false)
                {
                    Directory.CreateDirectory(Request.MapPath("~/Upload/" + DateTime.Now.ToString("yyyyMM")));
                }

                // 存储文件
                file.SaveAs(fileName);

                BGetTableDefineFromExcel bll = new BGetTableDefineFromExcel();
                var result = bll.GetTableDefineListFromExcel(fileName);

                BGeneratorSQL generatorSql = new BGeneratorSQL();
                var sqlResult = generatorSql.GeneratorSQL(result);
                return this.Json(new { IsSuccess = true, Result = sqlResult });
            }
            catch (Exception ex)
            {
                return this.Json(new { IsSuccess = false, ErrorMsg = ex.Message.ToString() });
            }
        }

        public ActionResult DownloadFile(string fileName, string contentType)
        {
            var path = Server.MapPath("~/Upload/" + fileName);
            var name = Path.GetFileName(path);
            return File(path, "application/zip-x-compressed", name);
        }
    }
}
