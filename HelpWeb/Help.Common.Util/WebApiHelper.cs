// ***********************************************************************
// Assembly         : Help.Common.Util
// Author           : zhujinrong
// Created          : 05-20-2016
//
// Last Modified By : zhujinrong
// Last Modified On : 05-20-2016
// ***********************************************************************
// <copyright file="WebApiHelper.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Help.Common.Util
{
    /// <summary>
    /// WebApiHelper
    /// </summary>
    public class WebApiHelper
    {
        private static readonly HttpClient httpClient;

        static WebApiHelper()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="url">url</param>
        /// <param name="req">req</param>
        /// <returns>结果</returns>
        public static T Post<T>(string url, string req)
        {
            string resjson = Post(url, req);

            if (string.IsNullOrEmpty(resjson))
            {
                return default(T);
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(resjson);
            }
        }

        /// <summary>
        /// Patch
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="url">url</param>
        /// <param name="req">req</param>
        /// <returns>结果</returns>
        public static T Patch<T>(string url, string req)
        {
            string resjson = Patch(url, req);

            if (string.IsNullOrEmpty(resjson))
            {
                return default(T);
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(resjson);
            }
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="url">url</param>
        /// <param name="data">data</param>
        /// <returns>结果</returns>
        public static T Get<T>(string url, string data)
        {
            string res = string.Empty;
            res = httpClient.GetAsync(url + "?" + data.ToString()).Result.Content.ReadAsStringAsync().Result;
            if (!string.IsNullOrEmpty(res))
            {
                T t = JsonConvert.DeserializeObject<T>(res);
                return t;
            }

            return default(T);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="url">url</param>
        /// <param name="paras">paras</param>
        /// <returns>T</returns>
        public static T Get<T>(string url, Dictionary<string, string> paras)
        {
            string ret = Get(url, paras);
            if (string.IsNullOrEmpty(ret))
            {
                return default(T);
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(ret);
            }
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="req">req</param>
        /// <returns>结果</returns>
        public static string Post(string url, string req)
        {
            HttpContent httpcontent = new StringContent(req);
            httpcontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string resjson = string.Empty;
            resjson = httpClient.PostAsync(url, httpcontent).Result.Content.ReadAsStringAsync().Result;

            return resjson;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="paras">paras</param>
        /// <returns>结果</returns>
        public static string Get(string url, Dictionary<string, string> paras)
        {
            StringBuilder querystring = new StringBuilder();

            if (paras != null && paras.Count > 0)
            {
                querystring.Append("?");
                foreach (var item in paras)
                {
                    querystring.AppendFormat("{0}={1}&", item.Key, item.Value);
                }
            }

            string res = string.Empty;

            res = httpClient.GetAsync(url + querystring.ToString()).Result.Content.ReadAsStringAsync().Result;

            return res;
        }

        /// <summary>
        /// 修复
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="req">req</param>
        /// <returns>结果</returns>
        public static string Patch(string url, string req)
        {
            HttpContent httpcontent = new StringContent(req);
            httpcontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string resjson = string.Empty;

            resjson = PatchAsync(httpClient, url, httpcontent).Result.Content.ReadAsStringAsync().Result;

            return resjson;
        }

        /// <summary>
        /// 帮助方法
        /// </summary>
        /// <param name="client">client</param>
        /// <param name="requestUri">requestUri</param>
        /// <param name="content">content</param>
        /// <returns>结果</returns>
        public async static Task<HttpResponseMessage> PatchAsync(HttpClient client, string requestUri, HttpContent content)
        {
            var method = new HttpMethod("PATCH");

            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = content
            };

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return response;
        }
    }
}
