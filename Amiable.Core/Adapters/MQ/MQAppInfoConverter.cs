using Amiable.SDK;
using Amiable.SDK.Interface;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Amiable.Adapter.MQ
{
    /// <summary>
    /// 允许将AppInfo转换为MQ可用的Json
    /// </summary>
    public class MQAppInfoConverter : IAppInfoConverter
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
                json.WriteString("skey", "SDG5D4Ys89h7DJ849d");
                json.WriteString("author", info.Author);
                json.WriteString("description", info.Description);
                json.WriteString("sdk", AmiableSDK.Version);
                json.WriteEndObject();
                json.Flush();
                json.Dispose();
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }
    }
}
