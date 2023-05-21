using MP_MB_MD.Web;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace MP_MB_MD.FunctionalTests.ControllerViews
{
    [Collection("Sequential")]
    public class HomeControllerIndex : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public HomeControllerIndex(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsViewWithCorrectMessage()
        {
            HttpResponseMessage response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            string stringResponse = await response.Content.ReadAsStringAsync();

            Assert.Contains("MP_MB_MD.Web", stringResponse);
        }
    }
}
