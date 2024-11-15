using Qonq.Medium.Model;
using System;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Qonq.Medium
{
    public class MediumClient
    {
        private const string _BaseUrl = "https://api.medium.com";
        private string _accessToken;

        public MediumClient(string accessToken)
        {
            _accessToken = accessToken;
        }
        public async Task<MediumUserResponse> GetCurrentUserAsync()
        {
            if (string.IsNullOrWhiteSpace(_accessToken))
                throw new ArgumentException("Access token cannot be null or empty.", nameof(_accessToken));

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_accessToken}");
                string url = $"{_BaseUrl}/v1/me";
                HttpResponseMessage httpResponse = await httpClient.GetAsync(url);

                if (httpResponse.IsSuccessStatusCode)
                {
                    string responseContent = await httpResponse.Content.ReadAsStringAsync();
                    if (string.IsNullOrWhiteSpace(responseContent))
                    {
                        throw new InvalidOperationException("Response content is null or empty.");
                    }
                    var result = JsonSerializer.Deserialize<MediumUserResponse>(responseContent);
                    return result ?? throw new InvalidOperationException("Deserialization returned null. Invalid response data.");
                }
                else
                {
                    var responseContent = await httpResponse.Content.ReadAsStringAsync();
                    throw new InvalidOperationException("API Request Failed");
                }
            }
        }
        public async Task<NewPostResponse> CreatePostAsync(string authorId, NewPostRequest postRequest)
        {
            if (string.IsNullOrWhiteSpace(_accessToken))
                throw new ArgumentException("Access token cannot be null or empty.", nameof(_accessToken));

            if (string.IsNullOrWhiteSpace(authorId))
                throw new ArgumentException("Author ID cannot be null or empty.", nameof(authorId));

            if (postRequest == null)
                throw new ArgumentNullException(nameof(postRequest));

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_accessToken}");
                string url = $"{_BaseUrl}/v1/users/{authorId}/posts";

                var jsonContent = JsonSerializer.Serialize(postRequest);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponse = await httpClient.PostAsync(url, httpContent);

                if (httpResponse.IsSuccessStatusCode)
                {
                    string responseContent = await httpResponse.Content.ReadAsStringAsync();
                    if (string.IsNullOrWhiteSpace(responseContent))
                    {
                        throw new InvalidOperationException("Response content is null or empty.");
                    }
                    return JsonSerializer.Deserialize<NewPostResponse>(responseContent) ??
                           throw new InvalidOperationException("Deserialization returned null. Invalid response data.");
                }
                else
                {
                    var responseContent = await httpResponse.Content.ReadAsStringAsync();
                    throw new InvalidOperationException($"API Request Failed: {responseContent}");
                }
            }
        }
    }
}