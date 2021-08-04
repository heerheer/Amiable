﻿#define Platform_XQ

using Amiable.SDK.Enum;
using Amiable.SDK.EventArgs;
using Amiable.SDK.Wrapper;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Amiable.Core
{
    public static partial class Export
    {
        //测试用导出函数，是个菜单
        [DllExport(CallingConvention.StdCall)]
        public static int Test()
        {
            return 0;//你是0
        }

        /// <summary>
        /// 预加载事件
        /// </summary>
        /// <param name="args"></param>
        private static void PreInitEvent(params object[] args)
        {
            //初始化API包装器
            try
            {
                AmiableService.App.DefaultApiWrapper.Init((short)args[0], (int)args[1]);
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
        private static string InitEvent(params object[] args)
        {

            try
            {
                AmiableService.RegEvents();

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
        private static void AfterInitEvent(params object[] args)
        {
            //TODO
        }


        public static void InvokeEvents(AmiableEventType type, AmiableEventArgs e)
        {
            try
            {
                //克隆ApiWrapper
                IApiWrapper apiWrapper = AmiableService.App.DefaultApiWrapper.Clone() as IApiWrapper;

                apiWrapper.SetData(e);//调用APIWrapper的SetData让Api包装器进行事件内数据变动。
                                      //例如改变机器人QQ

                e.ApiWrapper = apiWrapper;

                AmiableService.Events.FindAll(x => x.EventType == type).ForEach(x => x.Process(e));
            }
            catch (Exception ex)
            {

                AmiableService.App.Log($"[事件错误]\n来源:{ex.Source}\n问题:{ex.Message}\nStack{ex.StackTrace}");
            }
        }


    }
}