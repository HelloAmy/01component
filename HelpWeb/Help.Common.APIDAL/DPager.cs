using Help.Common.APIModel.PagerService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Common.APIDAL
{
    /// <summary>
    /// DPager
    /// </summary>
    public class DPager
    {
        /// <summary>
        /// GetData
        /// </summary>
        /// <param name="inparam">inparam</param>
        /// <param name="address">address</param>
        /// <returns>结果</returns>
        public MPagerOutParam GetData(MPagerInParam inparam, string address)
        {
            string json = JsonConvert.SerializeObject(inparam);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("json", json);
            return WebApiHelper.Get<MPagerOutParam>(address + "/", dic);
        }
    }
}
