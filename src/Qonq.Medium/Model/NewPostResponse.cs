using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Qonq.Medium.Model
{
    public class NewPostResponse
    {
        [JsonPropertyName("data")]
        public PostData Data { get; set; }
    }

    public class PostData
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("authorId")]
        public string AuthorId { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("canonicalUrl")]
        public string CanonicalUrl { get; set; }

        [JsonPropertyName("publishStatus")]
        public string PublishStatus { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }
    }
}
