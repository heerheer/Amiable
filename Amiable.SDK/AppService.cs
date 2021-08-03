using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Amiable.SDK.Wrapper;
using System.IO;
using Amiable.SDK.Interface;

namespace Amiable.SDK
{
    public class AppService
    {
        public IAppInfoConverter appInfoConverter;

        public IEventConverter EventConverter = new DefaultComponent.DefaultEventConverter();

        public AppInfo AppInfo;

        public IApiWrapper DefaultApiWrapper;

        /// <summary>
        /// 设置AppInfo转换文本实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void SetAppInfoConverter<T>() where T : IAppInfoConverter, new() => appInfoConverter = new T();
        
        public string GetAppInfoSring()
        {
            return appInfoConverter?.Convert(this.AppInfo);
        }

        /// <summary>
        /// 设置将框架事件代码转换为Amiable事件
        /// 默认为先驱提供的事件转换机制
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void SetEventConverter<T>() where T : IEventConverter, new() => EventConverter = new T();
    }

    public class AppInfo
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }

    }


}
