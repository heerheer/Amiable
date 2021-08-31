using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amiable.SDK.Wrapper;
using System.IO;
using Amiable.SDK.Interface;
using Amiable.SDK.DefaultComponent;

// ReSharper disable CollectionNeverQueried.Global

namespace Amiable.SDK
{
    public class AppService
    {
        private string _apiKey;

        /// <summary>
        /// 将AppInfo转化为框架识别JSON的转换器
        /// </summary>
        private Dictionary<string, IAppInfoConverter> _appInfoConverters = new();

        private static AppService _instance;

        /// <summary>
        /// 获取AppService实例（
        /// </summary>
        public static AppService Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new AppService();
                }

                return _instance;
            }
        }

        public AppService()
        {
            _instance = this;
        }


        /// <summary>
        /// 插件信息
        /// </summary>
        public AppInfo AppInfo;

        /// <summary>
        /// Api包装器的初始实例
        /// </summary>
        public IApiWrapper DefaultApiWrapper
        {
            get
            {
                if (string.IsNullOrEmpty(_apiKey))
                {
                    return ApiWrappers.First().Value;
                }

                if (ApiWrappers.ContainsKey(_apiKey) is false)
                {
                    return ApiWrappers.First().Value;
                }

                return ApiWrappers[_apiKey];
            }
        }

        /// <summary>
        /// 构造Code的工具
        /// </summary>
        public CodeProvider DefaultCodeProvider
        {
            get
            {
                if (string.IsNullOrEmpty(_apiKey))
                {
                    return CodeProviders.First().Value;
                }

                if (ApiWrappers.ContainsKey(_apiKey) is false)
                {
                    return CodeProviders.First().Value;
                }

                return CodeProviders[_apiKey];
            }
        }

        /// <summary>
        /// 一堆API包装器
        /// </summary>
        public Dictionary<string, IApiWrapper> ApiWrappers = new();


        public Dictionary<string, CodeProvider> CodeProviders = new();

        /// <summary>
        /// 请在create函数设置AppService.Instance的apiKey用于识别API
        /// </summary>
        /// <param name="key"></param>
        public void SetApiKey(string key)
        {
            _apiKey = key;
        }

        public List<IEventFilter> EventFilters = new();

        /// <summary>
        /// 设置AppInfo转换文本实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void AddAppInfoConverter<T>(string key) where T : IAppInfoConverter, new() =>
            _appInfoConverters.Add(key, new T());


        public string GetAppInfoSring() => _appInfoConverters[_apiKey].Convert(AppInfo);


        #region 日志相关方法

        /// <summary>
        /// 以Amiable.Core的方式输出日志文本
        /// </summary>
        /// <param name="args"></param>
        public void Log(params object[] args)
        {
            var dir = Path.Combine(Directory.GetCurrentDirectory(), "Amiable");
            if (Directory.Exists(dir) is false)
            {
                Directory.CreateDirectory(dir);
            }

            var path = Path.Combine(dir, $"{AppInfo?.Name ?? "Amiable"}.{DateTime.Now:yyMMdd}.log");
            File.AppendAllText(path, $"[{DateTime.Now.ToShortTimeString()}]{string.Join("", args)}\n");
        }

        /// <summary>
        /// 以Amiable.Core的方式输出调试类型的日志文本
        /// </summary>
        /// <param name="args"></param>
        public void Debug(params object[] args)
        {
            Log("[Debug]", args);
        }

        #endregion
    }
}