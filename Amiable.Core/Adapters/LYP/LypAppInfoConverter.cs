using System.IO;
using System.Text;
using System.Text.Json;
using Amiable.SDK;
using Amiable.SDK.Interface;

namespace Amiable.Adapters.LYP
{
    /// <summary>
    /// 允许将AppInfo转换为MQ可用的Json
    /// </summary>
    public class LypAppInfoConverter : IAppInfoConverter
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
                json.WriteString("name", info.Name);
                json.WriteString("version", info.Version);
                json.WriteString("id", info.AppId);
                json.WriteString("author", info.Author);
                json.WriteString("description", info.Description);
                json.WriteString("icon", $"{info.AppId}.png");
                json.WriteString("type", $"Amiable");
                json.WriteString("sdkVer", AmiableSDK.Version);
                json.WriteString("menuA", $"设置窗口A");
                json.WriteString("menuB", $"设置窗口B");

                json.WriteEndObject();
                json.Flush();
                json.Dispose();
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }
    }
}