using NUnit.Framework;
using Reqnroll;
using System.Net.Http;

namespace IntegrationTestsDemo.BDD.Support
{
    [Binding]
    public class TestsWithFactory
    {
        public HttpClient Client { get; set; }

        [OneTimeSetUp]
        [BeforeScenario(Order = 100)]
        public void Setup(TestContainerSetup testContainerSetup)
        {
            var integrationTestFactory = new IntegrationTestFactory<Program>(testContainerSetup.ConnectionString!);
            Client = integrationTestFactory.CreateClient();
        }

     
        [TearDown]
        public void TearDown()
        {
            Client.Dispose();
        }
    }
}