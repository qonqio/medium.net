using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Qonq.Medium.Model
{
    public class ErrorResponse
    {
        [JsonPropertyName("errors")]
        public List<ErrorDetail> Errors { get; set; }
    }

    public class ErrorDetail
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("code")]
        public int Code { get; set; }
    }
}
