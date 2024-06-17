namespace IntegrationTestsDemo.TestContainers
{
    [TestFixture]
    public class TestsWithoutFactory : TestContainerSetup
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestToSeeConnectionStringForTestContainer()
        {
            Console.WriteLine(ConnectionString);
            Assert.IsNotEmpty(ConnectionString);
        }
    }
}