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

        public JsonResult ImportExcelFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength == 0)
                {
                    return this.Json(new { IsSuccess = false, ErrorMsg = "没有文件！" });
                }

                var fileName = Path.Combine(Request.MapPath("~/Upload"), Path.GetFileName(file.FileName));

                file.SaveAs(fileName);

                return this.Json(new { IsSuccess = true });
            }
            catch (Exception ex)
            {
                return this.Json(new { IsSuccess = false, ErrorMsg = ex.Message.ToString() });
            }
        }
    }
}
