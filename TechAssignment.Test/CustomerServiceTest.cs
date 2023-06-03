using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using Implementation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechAssignment.Test.Fixture;

namespace TechAssignment.Test
{
    public class CustomerServiceTest : IClassFixture<TechAssignmentTestFixture>
    {
        private readonly TechAssignmentTestFixture _fixture;
        private readonly ICustomerProvider _customerService;

        public CustomerServiceTest(TechAssignmentTestFixture fixture)
        {
            _fixture = fixture;
            _customerService = fixture.GetCustomerProvider();
        }

        [Fact]
        public void GetAllCustomers_ShouldReturnCollectionOfCustomers()
        {
            // Arrange
            List<Customer> customers = new()
            {
                new Customer()
                {
                    Id = Guid.NewGuid(),
                    Name = "First City",
                    CityId = Guid.NewGuid()
                },
                new Customer()
                {
                    Id = Guid.NewGuid(),
                    Name = "Second City",
                    CityId = Guid.NewGuid()
                }
            };

            _fixture.CustomerProviderMock.Setup(x => x.GetAllCustomers())
                .Returns(customers);

            // Act
            List<Customer> dbCustomers = _customerService.GetAllCustomers();

            // Assert
            Assert.NotNull(dbCustomers);
            Assert.True(dbCustomers.Count == 2);
            Assert.Equal(customers.First().Id, dbCustomers.First().Id);
            Assert.Equal(customers.First().Name, dbCustomers.First().Name);
            Assert.Equal(customers.First().CityId, dbCustomers.First().CityId);
        }
    }
}
