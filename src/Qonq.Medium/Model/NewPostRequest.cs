using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Qonq.Medium.Model
{
    public class NewPostRequest
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("contentFormat")]
        public string ContentFormat { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("canonicalUrl")]
        public string CanonicalUrl { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("publishStatus")]
        public string PublishStatus { get; set; }

        [JsonPropertyName("notifyFollowers")]
        public bool NotifyFollowers { get; set; }
    }
}
