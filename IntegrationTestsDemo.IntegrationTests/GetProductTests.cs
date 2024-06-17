namespace IntegrationTestsDemo.IntegrationTests
{
    public class Tests
    {
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
          var integrationTestFactory  = new IntegrationTestFactory<Program>();
          _client = integrationTestFactory.CreateClient();
        }

        [Test]
        public async Task Get_all_products()
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod("GET"), "/products");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
        }
    }
}