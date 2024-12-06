using Infra.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Infra.Ioc.Tests
{
    public class ExtensionsTest
    {
        private readonly IServiceCollection _services;
        private readonly IServiceProvider _provider;

        public ExtensionsTest()
        {
            var mockConfiguration = new Mock<IConfiguration>();

            mockConfiguration.Setup(config => config.GetSection("ConnectionStrings")["MSSQL"])
                             .Returns("Server=server; Database=db; User Id=user; Password=123456;"); ;

            _services = new ServiceCollection();
            _services.AddExtensions(mockConfiguration.Object);

            _provider = _services.BuildServiceProvider();
        }

        [Fact]
        public void ShouldAddDbContext()
        {
            var dbContext1 = _provider.GetService<DatabaseContext>();
            var dbContext2 = _provider.GetService<DatabaseContext>();

            Assert.Same(dbContext1, dbContext2);
            Assert.IsType<DatabaseContext>(dbContext1);
            Assert.IsType<DatabaseContext>(dbContext2);
        }
    }
}