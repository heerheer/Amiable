using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Amiable.SDK.Tool
{
    /// <summary>
    /// 一个HTTP帮助类，轻松使用GET POST
    /// </summary>
    public class HttpHelper
    {
        /// <summary>
        /// Get数据
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string Get(string url)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    return client.GetStringAsync(url).Result;
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }
        public static string Get(string url, Dictionary<string, string> values)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var querystr = string.Join("&",values.Select(x => x.Key + "=" + x.Value));
                    return client.GetStringAsync($"{url}?{querystr}").Result;
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }
        
        
        /// <summary>
        /// post表单
        /// </summary>
        /// <param name="url"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string Post(string url, List<KeyValuePair<string, string>> values)
        {
            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(values);

                var response = client.PostAsync(url, content);

                var responseString = response.Result.Content.ReadAsStringAsync();

                return responseString.Result;
            }
        }

        /// <summary>
        /// post Json数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static string Post(string url, string body)
        {
            using (var client = new HttpClient())
            {
                var content = new StringContent(body);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var response = client.PostAsync(url, content);

                var responseString = response.Result.Content.ReadAsStringAsync();

                return responseString.Result;
            }
        }
    }
}