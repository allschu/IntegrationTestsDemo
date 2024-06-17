using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace IntegrationTestsDemo.IntegrationTests
{
    public class IntegrationTestFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("IntegrationTests");

            builder.ConfigureServices(services =>
            {
                //Fake the authentication
                //services.AddAuthentication("UnitTest")
                //    .AddScheme<AuthenticationSchemeOptions, FakeAuthenticationHandler>(
                //        "UnitTest", options => { });

                //services.AddDbContext<BoxwiseDbContext>(options => options.UseInMemoryDatabase("IntegrationTests"));});
            });
        }
    }
}
