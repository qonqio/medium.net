using Qonq.Medium.Model;

namespace Qonq.Medium.Tests
{
    public class UserProfileTests
    {
        [Fact]
        public async Task GetUserTest()
        {
            var accessToken = Environment.GetEnvironmentVariable("MEDIUM_ACCESS_TOKEN");
            var client = new MediumClient(accessToken);
            var response = await client.GetCurrentUserAsync();

            Assert.NotNull(response);
        }
        [Fact]
        public async Task CreateNewPostTest()
        {
            var accessToken = Environment.GetEnvironmentVariable("MEDIUM_ACCESS_TOKEN");
            var client = new MediumClient(accessToken);
            var userResponse = await client.GetCurrentUserAsync();

            var authorId = userResponse.Data.Id;
            var newPostRequest = new NewPostRequest()
            {
                Title = "Beep Beep Boop",
                Content = "# Hello World\n\n\n## Just a Test\n\n\nHello.",
                ContentFormat = "markdown",
                Tags = new List<string> { "AI" },
                PublishStatus = "unlisted",
                NotifyFollowers = false
            };

            var response = await client.CreatePostAsync(authorId, newPostRequest);

            Assert.NotNull(response);
        }
    }
}