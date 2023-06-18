using System.Text.Json.Serialization;

namespace MuntersProject.Core.Model
{
    public class GifImage
    {
        [JsonPropertyName("original")]
        public Original Original { get; set; }
       
    }
}