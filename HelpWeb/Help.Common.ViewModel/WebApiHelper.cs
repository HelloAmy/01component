using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Help.Common.ViewModel
{
    //public class WebApiHelper
    //{
    //    private static string serviceAddress = "http://localhost:6293";

    //    public static T Post<T>(string url, string req)
    //    {
    //        if (url.ToUpper().IndexOf("HTTP") == -1)
    //        {
    //            url = serviceAddress + url;
    //        }

    //        string resjson = Post(url, req);

    //        if (string.IsNullOrEmpty(resjson))
    //        {
    //            return default(T);
    //        }
    //        else
    //        {
    //            return JsonConvert.DeserializeObject<T>(resjson);
    //        }
    //    }

    //    public static T Patch<T>(string url, string req)
    //    {
    //        if (url.ToUpper().IndexOf("HTTP") == -1)
    //        {
    //            url = serviceAddress + url;
    //        }

    //        string resjson = Patch(url, req);

    //        if (string.IsNullOrEmpty(resjson))
    //        {
    //            return default(T);
    //        }
    //        else
    //        {
    //            return JsonConvert.DeserializeObject<T>(resjson);
    //        }
    //    }

    //    public static string Post(string url, string req)
    //    {
    //        if (url.ToUpper().IndexOf("HTTP") == -1)
    //        {
    //            url = serviceAddress + url;
    //        }

    //        HttpContent httpcontent = new StringContent(req);
    //        httpcontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

    //        string resjson = string.Empty;
    //        using (HttpClient httpclient = new HttpClient())
    //        {
    //            resjson = httpclient.PostAsync(url, httpcontent).Result.Content.ReadAsStringAsync().Result;
    //        }

    //        return resjson;
    //    }

    //    public static string Get(string url, Dictionary<string, string> paras)
    //    {
    //        StringBuilder querystring = new StringBuilder();

    //        if (paras != null && paras.Count > 0)
    //        {
    //            querystring.Append("?");
    //            foreach (var item in paras)
    //            {
    //                querystring.AppendFormat("{0}={1}&", item.Key, item.Value);
    //            }
    //        }

    //        string res = string.Empty;
    //        using (HttpClient httpclient = new HttpClient())
    //        {
    //            res = httpclient.GetAsync(url + querystring.ToString()).Result.Content.ReadAsStringAsync().Result;
    //        }

    //        return res;
    //    }

    //    public static string Patch(string url, string req)
    //    {
    //        if (url.ToUpper().IndexOf("HTTP") == -1)
    //        {
    //            url = serviceAddress + url;
    //        }

    //        HttpContent httpcontent = new StringContent(req);
    //        httpcontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

    //        string resjson = string.Empty;
    //        using (HttpClient httpclient = new HttpClient())
    //        {
    //            resjson = httpclient.PatchAsync(url, httpcontent).Result.Content.ReadAsStringAsync().Result;
    //        }

    //        return resjson;
    //    }
       
    //}
}
