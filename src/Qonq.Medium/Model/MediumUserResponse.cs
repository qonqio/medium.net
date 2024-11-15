using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Qonq.Medium.Model
{
    public class MediumUserResponse
    {
        [JsonPropertyName("data")]
        public MediumUserData Data { get; set; }
    }
}
