using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MuntersProject.Core.Model
{
    public class TrengingGif
    {
        [JsonPropertyName("data")]
        public List<Data> Data { get; set; }
    }
}
