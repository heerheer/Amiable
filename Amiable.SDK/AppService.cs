using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amiable.SDK.Wrapper;
using System.IO;
using Amiable.SDK.Interface;
using Amiable.SDK.Configuration;

namespace Amiable.SDK
{
    public class AppService
    {
        /// <summary>
        /// 将AppInfo转化为框架识别JSON的转换器
        /// </summary>
        private IAppInfoConverter appInfoConverter;

        private static AppService instance;

        /// <summary>
        /// 获取AppService实例（
        /// </summary>
        public static AppService Instance {

            get { 
                if(instance is null)
                {
                    instance = new AppService();
                }
                return instance;
            }
        }

        public AppService()
        {
            instance=this;
        }


        /// <summary>
        /// 插件信息
        /// </summary>
        public AppInfo AppInfo;

        /// <summary>
        /// Api包装器的初始实例
        /// </summary>
        public IApiWrapper DefaultApiWrapper;

        public Dictionary<string, IApiWrapper> ApiWrappers = new();

        public List<IEventFilter> EventFilters = new();
        public List<IService> Services = new();

        /// <summary>
        /// 设置AppInfo转换文本实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void SetAppInfoConverter<T>() where T : IAppInfoConverter, new() => appInfoConverter = new T();

        public string GetAppInfoSring() => appInfoConverter.Convert(AppInfo);


        #region 日志相关方法
        /// <summary>
        /// 以Amiable.Core的方式输出日志文本
        /// </summary>
        /// <param name="args"></param>
        public void Log(params object[] args)
        {
            var dir = Path.Combine(Directory.GetCurrentDirectory(), "Amiable");
            if(Directory.Exists(dir) is false)
            {
                Directory.CreateDirectory(dir);
            }
            var path = Path.Combine(dir, $"{AppInfo?.Name ?? "Amiable"}.{DateTime.Now:yyMMdd}.log");
            File.AppendAllText(path, $"[{DateTime.Now.ToShortTimeString()}]{string.Join("",args)}\n");
        }

        /// <summary>
        /// 以Amiable.Core的方式输出调试类型的日志文本
        /// </summary>
        /// <param name="args"></param>
        public void Debug(params object[] args)
        {
            Log("[Debug]",args);
        }
        #endregion
    }


}
