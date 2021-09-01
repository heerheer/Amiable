using Amiable.SDK;
using Amiable.SDK.Interface;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Amiable.Adapter.Ono
{
    /// <summary>
    /// 允许将AppInfo转换为先驱可用的Json
    /// </summary>
    public class XQAppInfoConverter : IAppInfoConverter
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
                System.Text.Json.Utf8JsonWriter json = new(stream, options);
                json.WriteStartObject();
                json.WriteString("name", info.Name);
                json.WriteString("pver", info.Version);
                json.WriteNumber("sver", 3);
                json.WriteString("author", info.Author);
                json.WriteString("desc", info.Description);
                json.WriteEndObject();
                json.Flush();
                json.Dispose();
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }
    }
}
