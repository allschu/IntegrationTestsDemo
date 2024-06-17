using IntegrationTestsDemo.BDD.Support;
using Newtonsoft.Json;
using Reqnroll;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IntegrationTestsDemo.Contracts;
using Shouldly;

namespace IntegrationTestsDemo.BDD.StepDefinitions
{
    [Binding]
    public class ProductsStepDefinitions
    {
        private readonly TestsWithFactory _context;

        public ProductsStepDefinitions(TestsWithFactory context)
        {
            _context = context;
        }

        [Given("the user is authenticated as warehouse manager")]
        public async Task GivenTheUserIsAuthenticatedAsWarehouseManager()
        {
            _context.ShouldNotBeNull("because we are already authenticated");   
        }

        [When("the user opens the product management page")]
        public async Task WhenTheUserOpensTheProductManagementPage()
        {
            var request = new HttpRequestMessage(new HttpMethod("GET"), "/products");
            
            var response = await _context.Client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
        }

        [Then("the user needs to be able to add a new product")]
        public async Task ThenTheUserNeedsToBeAbleToAddANewProduct()
        {
            var request = new HttpRequestMessage(new HttpMethod("POST"), "/products");
            request.Content = new StringContent(JsonConvert.SerializeObject(new AddProductRequest
            {
                Name = "Product 1",
                Price = 10
            }), Encoding.UTF8, "application/json");

            // Act
            var response = await _context.Client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.Created);
        }
    }
}
