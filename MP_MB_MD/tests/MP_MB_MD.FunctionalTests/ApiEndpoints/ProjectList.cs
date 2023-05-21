using Ardalis.HttpClientTestExtensions;
using MP_MB_MD.Web;
using MP_MB_MD.Web.Endpoints.ProjectEndpoints;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace MP_MB_MD.FunctionalTests.ApiEndpoints
{
    [Collection("Sequential")]
    public class ProjectList : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ProjectList(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsOneProject()
        {
            var result = await _client.GetAndDeserialize<ProjectListResponse>("/Projects");

            Assert.Single(result.Projects);
            Assert.Contains(result.Projects, i => i.Name == SeedData.TestProject1.Name);
        }
    }
}
