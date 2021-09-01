#define Platform_XQ

using Amiable.SDK.Enum;
using Amiable.SDK.EventArgs;
using Amiable.SDK.Wrapper;
using HuajiTech.UnmanagedExports;
using System;

namespace Amiable.Core.Service
{
    public static class EventCore
    {
        //测试用导出函数，是个菜单
        [DllExport]
        public static int Test()
        {
            return 0;//你是0
        }

        /// <summary>
        /// 预加载事件
        /// </summary>
        /// <param name="args"></param>
        public static void PreInitEvent(params object[] args)
        {
            //初始化API包装器
            try
            {
                AmiableService.App.SetApiKey(AmiableService.ApiKey);
                AmiableService.App.DefaultApiWrapper.Init(args);
            }
            catch (Exception ex)
            {
                AmiableService.App.Log(ex.ToString());
            }
        }

        /// <summary>
        /// 创建插件事件(需要返回JSON时)
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string InitEvent(params object[] args)
        {

            try
            {
                AmiableService.App.SetApiKey(AmiableService.ApiKey);
                return AmiableService.App.GetAppInfoSring();
            }
            catch (Exception ex)
            {
                AmiableService.App.Log(ex.ToString());
                return "";
            }
        }

        /// <summary>
        /// 插件创建完成
        /// </summary>
        /// <param name="args"></param>
        public static void AfterInitEvent(params object[] args)
        {
            AmiableService.App.SetApiKey(AmiableService.ApiKey);
            //TODO
        }


        /// <summary>
        /// 触发一个事件
        /// </summary>
        /// <param name="type"></param>
        /// <param name="e"></param>
        public static void InvokeEvents(AmiableEventType type, AmiableEventArgs e)
        {
            try
            {
                AmiableService.App.SetApiKey(AmiableService.ApiKey);
                //克隆ApiWrapper
                IApiWrapper apiWrapper = AmiableService.App.DefaultApiWrapper.Clone() as IApiWrapper;

                apiWrapper.SetData(e);
                //调用APIWrapper的SetData让Api包装器进行事件内数据变动。
                //例如改变机器人QQ

                e.ApiWrapper = apiWrapper;

                e.AppInfo = AmiableService.App.AppInfo;

                AmiableService.Events.FindAll(x => x.EventType == type).ForEach(x =>
                {
                    x.Process(e);
                }


                );
            }
            catch (Exception ex)
            {

                AmiableService.App.Log($"[事件错误]\n来源:{ex.Source}\n问题:{ex.Message}\nStack{ex.StackTrace}");
            }
        }

        public static AmiableEventArgs GetAmiableEventArgs(long timestamp, long robot, EventType eventType)
        {
            return new AmiableEventArgs
            {
                Timestamp = timestamp,
                Robot = robot,
                EventType = eventType
            };
        }

    }
}