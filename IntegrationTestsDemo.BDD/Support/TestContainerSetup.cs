using System.Data.SqlClient;
using System.Threading.Tasks;
using NUnit.Framework;
using Reqnroll;
using Testcontainers.MsSql;

namespace IntegrationTestsDemo.BDD.Support
{
    [Binding]
    [TestFixture]
    public class TestContainerSetup
    {
        public string? ConnectionString { get; private set; }

        private readonly MsSqlContainer _msSqlContainer = new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
            .WithPassword("Password123")
            //.WithCleanUp(false) // Uncomment this line to keep the container running after tests
            .Build();


        [OneTimeSetUp]
        [BeforeScenario(Order = 1)]
        public async Task Init()
        {
            await _msSqlContainer.StartAsync();
            await _msSqlContainer.CopyAsync("BOXwiseProDev_New.bak", "/var/opt/mssql/data/");

            RestoreBoXwiseProDevDatabase();
        }

        private void RestoreBoXwiseProDevDatabase()
        {
            var connectionString = _msSqlContainer.GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var restoreCommand = new SqlCommand(@"
                    RESTORE DATABASE BOXwiseProDev
                    FROM DISK = N'/var/opt/mssql/data/BOXwiseProDev_New.bak'", connection);

                restoreCommand.ExecuteNonQuery();
                connection.Close();
            }

            ConnectionString = connectionString.Replace("master", "BOXwiseProDev");
        }

        [OneTimeTearDown]
        public async Task Cleanup()
        {
            await _msSqlContainer.DisposeAsync();
        }
    }
}
