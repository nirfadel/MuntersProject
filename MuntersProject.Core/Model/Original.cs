using System.Text.Json.Serialization;

namespace MuntersProject.Core.Model
{
    public class Original
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}