using System.Text.Json.Serialization;

namespace MuntersProject.Core.Model
{
    public class Data
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("images")]
        public GifImage Images { get; set; }
        
    }
}