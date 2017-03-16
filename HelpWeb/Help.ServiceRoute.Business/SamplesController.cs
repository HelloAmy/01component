using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Help.ServiceRoute.Business
{
    public class SamplesController : Controller
    {
        public ActionResult BaiduEcharts()
        {
            return this.View();
        }
    }
}
