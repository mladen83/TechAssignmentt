using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechAssignment.Test.Fixture;

namespace TechAssignment.Test
{
    public class SalesServiceTest : IClassFixture<TechAssignmentTestFixture>
    {

        private readonly TechAssignmentTestFixture _fixture;
        private readonly ISalesProvider _saleService;

        public SalesServiceTest(TechAssignmentTestFixture fixture)
        {
            _fixture = fixture;
            _saleService = _fixture.GetSalesProvider();
        }

        [Fact]
        public void GetAllSalesForCustomer_ShouldReturnListOfSalesForCustomer()
        {
            //Arrange
            List<Sale> sales = new()
            {
                new Sale()
                {
                    Id = Guid.NewGuid(),
                    CustomerId = Guid.NewGuid(),
                    DateOfSale = DateTime.Now,
                    PricePerPiece = 1.45M,
                    ProductId = Guid.NewGuid(),
                    Quantity = 12
                }
            };

            _fixture.SalesProviderMock
                .Setup(x => x.GetAllSalesForCustomer(It.IsAny<Guid>()))
                .Returns(sales);

            //Act
            List<Sale> dbSales = _saleService.GetAllSalesForCustomer(Guid.NewGuid());

            //Assert
            Assert.NotNull(dbSales);
            Assert.Single(dbSales);
            Assert.Equal(sales.First().Id, dbSales.First().Id);
            Assert.Equal(sales.First().CustomerId, dbSales.First().CustomerId);
            Assert.Equal(sales.First().DateOfSale, dbSales.First().DateOfSale);
            Assert.Equal(sales.First().PricePerPiece, dbSales.First().PricePerPiece);
            Assert.Equal(sales.First().ProductId, dbSales.First().ProductId);
            Assert.Equal(sales.First().Quantity, dbSales.First().Quantity);
        }

        [Fact]
        public void GetEarliestSaleDate_ShouldReturnMinDate_Value()
        {
            //Arrange
            DateTime minDateTime = new DateTime(2020, 12, 23);

            List<Sale> sales = new()
            {
                new Sale()
                {
                    Id = Guid.NewGuid(),
                    CustomerId = Guid.NewGuid(),
                    DateOfSale = minDateTime.AddDays(2),
                    PricePerPiece = 1.41M,
                    ProductId = Guid.NewGuid(),
                    Quantity = 12
                },
                new Sale()
                {
                    Id = Guid.NewGuid(),
                    CustomerId = Guid.NewGuid(),
                    DateOfSale = minDateTime.AddHours(4),
                    PricePerPiece = 1.42M,
                    ProductId = Guid.NewGuid(),
                    Quantity = 12
                },
                new Sale()
                {
                    Id = Guid.NewGuid(),
                    CustomerId = Guid.NewGuid(),
                    DateOfSale = minDateTime,
                    PricePerPiece = 1.43M,
                    ProductId = Guid.NewGuid(),
                    Quantity = 12
                }
            };

            _fixture.SalesProviderMock
                .Setup(x => x.GetEarliestSaleDate())
                .Returns(minDateTime);

            //Act

            DateTime? dbMinDateTime = _saleService.GetEarliestSaleDate();

            //Assert
            Assert.NotNull(dbMinDateTime);
            Assert.Equal(minDateTime, dbMinDateTime.Value);
        }

        [Fact]
        public void GetEarliestSaleDate_ShouldReturn_Null()
        {
            //Arrange
            //DateTime minDateTime = new DateTime(2020, 12, 23);

            //Act

            DateTime? dbMinDateTime = _saleService.GetEarliestSaleDate();

            //Assert
            Assert.Null(dbMinDateTime);
        }
    }
}
