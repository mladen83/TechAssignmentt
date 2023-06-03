using DataAccessLibrary.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechAssignment.Test.Fixture
{
    public class TechAssignmentTestFixture
    {
        public Mock<ICustomerProvider> CustomerProviderMock = new();
        public Mock<ISalesProvider> SalesProviderMock = new();

        public TechAssignmentTestFixture()
        {
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    webHost.UseStartup<StartupTest>();
                });
        }

        public ICustomerProvider GetCustomerProvider()
        {
            return CustomerProviderMock.Object;
        }

        public ISalesProvider GetSalesProvider()
        {
            return SalesProviderMock.Object;
        }
}
}
