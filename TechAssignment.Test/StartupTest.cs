using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Providers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechAssignment.Test
{
    public class StartupTest
    {
        public StartupTest()
        {

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICustomerProvider, CustomerProvider>();
            services.AddSingleton<ISalesProvider, SaleProvider>();
        }
    }
}
