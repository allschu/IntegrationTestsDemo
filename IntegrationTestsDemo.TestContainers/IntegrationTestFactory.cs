using IntegrationTestsDemo.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTestsDemo.TestContainers
{
    public class IntegrationTestFactory<TProgram>(string connectionString) : WebApplicationFactory<TProgram>
        where TProgram : class
    {
        // This is the constructor that will be called when the test is run

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("IntegrationTests");

            builder.ConfigureServices(services =>
            {
                //Fake the authentication
                //services.AddAuthentication("UnitTest")
                //    .AddScheme<AuthenticationSchemeOptions, FakeAuthenticationHandler>(
                //        "UnitTest", options => { });
                
                //services.AddDbContext<BoxwiseDbContext>(builder => builder.UseInMemoryDatabase("IntegrationTests"));
                services.AddDbContext<BoxwiseDbContext>(options => options.UseSqlServer(connectionString));
            });
        }
    }
}
