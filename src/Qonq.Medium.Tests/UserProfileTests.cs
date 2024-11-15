using Qonq.Medium.Model;

namespace Qonq.Medium.Tests
{
    public class UserProfileTests
    {
        [Fact]
        public async Task GetUserTest()
        {
            var accessToken = "";
            var client = new MediumClient(accessToken);
            var response = await client.GetCurrentUserAsync();

            Assert.NotNull(response);
        }
        [Fact]
        public async Task CreateNewPostTest()
        {
            var accessToken = "";
            var client = new MediumClient(accessToken);

            var authorId = "foo";
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