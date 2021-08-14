using System.IO;
using System.Text;
using System.Text.Json;
using Amiable.SDK;
using Amiable.SDK.Interface;

namespace Amiable.Adapters.Xlz
{
    /// <summary>
    /// 允许将AppInfo转换为MQ可用的Json
    /// </summary>
    public class XlzAppInfoConverter : IAppInfoConverter
    {
        public string Convert(AppInfo info)
        {
            using (var stream = new MemoryStream())
            {
                var options = new JsonWriterOptions
                {
                    Indented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                System.Text.Json.Utf8JsonWriter json = new Utf8JsonWriter(stream, options);
                json.WriteStartObject();
                json.WriteString("appname", info.Name);
                json.WriteString("appv", info.Version);
                json.WriteString("author", info.Author);
                json.WriteString("describe", info.Description);
                json.WriteString("sdkv", AmiableSDK.Version);

                foreach (var handler in XlzApiWrapper.HandlerIntptrs)
                {
                    json.WriteNumber(handler.Key, handler.Value);
                }


                json.WriteStartObject("data");

                {
                    json.WriteStartObject("needapilist");

                    var needApi = new[] { "发送群消息", "发送好友消息", "输出日志" };

                    foreach (var apistr in needApi)
                    {
                        json.WriteStartObject(apistr);
                        {
                            json.WriteString("state", "1");
                            json.WriteString("safe", "1");
                        }
                        json.WriteEndObject();
                    }

                    json.WriteEndObject(); //needapilist
                }

                json.WriteEndObject(); //data


                json.WriteEndObject(); //root
                json.Flush();

                var jsonstr = Encoding.UTF8.GetString(stream.ToArray());
                AppService.Instance.Log(jsonstr);
                json.Dispose();
                return jsonstr;
            }
        }
    }
}