using IntegrationTestsDemo.Contracts;
using Newtonsoft.Json;
using System.Text;

namespace IntegrationTestsDemo.TestContainers
{
    [TestFixture]
    public class TestsWithFactory : TestContainerSetup
    {
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            var integrationTestFactory = new IntegrationTestFactory<Program>(ConnectionString!);
            _client = integrationTestFactory.CreateClient();
        }

        [Test]
        public async Task AddProductWithTestContainer()
        {

            // Arrange
            var request = new HttpRequestMessage(new HttpMethod("POST"), "/products");
            request.Content = new StringContent(JsonConvert.SerializeObject(new AddProductRequest
            {
                Name = "Product 1",
                Price = 10
            }), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.SendAsync(request);

        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
        }
    }
}