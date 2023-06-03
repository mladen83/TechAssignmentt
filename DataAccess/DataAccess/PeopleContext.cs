using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLibrary.DataAccess
{
    public class PeopleContext : DbContext
    {
        public PeopleContext()
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TechAssignmentDB;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Guid firstCityGuid = Guid.NewGuid();
            Guid secondCityGuid = Guid.NewGuid();
            builder.Entity<City>().HasData(GetCities(firstCityGuid, secondCityGuid));


            Guid firstProductGuid = Guid.NewGuid();
            Guid secondProductGuid = Guid.NewGuid();
            builder.Entity<Product>().HasData(GetProducts(firstProductGuid, secondProductGuid));


            Guid firstCustomerGuid = Guid.NewGuid();
            Guid secondCustomerGuid = Guid.NewGuid();
            builder.Entity<Customer>().HasData(GetCustomers(firstCustomerGuid, secondCustomerGuid, firstCityGuid, secondCityGuid));

            List<Guid> customerGuids = new()
            {
                firstCustomerGuid, secondCustomerGuid
            };
            List<Guid> productGuids = new()
            {
                firstProductGuid, secondProductGuid
            };
            builder.Entity<Sale>().HasData(GetSales(customerGuids, productGuids));
        }

        #region Cities

        private List<City> GetCities(Guid firstCityGuid, Guid secondCityGuid)
        {
            List<City> cities = new()
            {
                new()
                {
                    Id = firstCityGuid,
                    Name = "Heidel"
                },

                new()
                {
                    Id = secondCityGuid,
                    Name = "Arborstone"
                }
            };

            return cities;
        }
        #endregion Cities

        #region Products
        private List<Product> GetProducts(Guid firstProductGuid, Guid secondProductGuid)
        {
            List<Product> products = new()
            {
                new()
                {
                    Id = firstProductGuid,
                    Name = "Ring"
                },

                new()
                {
                    Id = secondProductGuid,
                    Name = "Necklace"
                }
            };

            return products;
        }
        #endregion Products

        #region Customers
        private List<Customer> GetCustomers(
            Guid firstCustomerGuid, 
            Guid secondCustomerGuid, 
            Guid firstCityGuid, 
            Guid secondCityGuid)
        {
            List<Customer> customers = new()
            {
                new()
                {
                    Id = firstCustomerGuid,
                    Name = "Best Customer",
                    CityId = firstCityGuid
                },

                new()
                {
                    Id = secondCustomerGuid,
                    Name = "Worst Customer",
                    CityId = secondCityGuid
                }
            };

            return customers;
        }

        private List<Sale> GetSales(List<Guid> customerGuids, List<Guid> productGuids)
        {
            List<Sale> sales = new();

            Random random = new Random();

            for (int i = 2010; i < 2023; i++)
            {
                int customerIndex = random.Next(customerGuids.Count);
                int productIndex = random.Next(productGuids.Count);

                Sale sale = new()
                {
                    Id = Guid.NewGuid(),
                    CustomerId = customerGuids[customerIndex],
                    ProductId = productGuids[productIndex],
                    Quantity = random.Next(5, 20),
                    DateOfSale = new DateTime(
                        i,
                        random.Next(1, 12),
                        random.Next(1, 28)
                        ),
                    PricePerPiece = GetRandomPrice(random, 104.25, 851.46, 2)
                };
                sales.Add(sale);
            }

            return sales;
        }

        private decimal GetRandomPrice(Random random, double maxValue, double minValue, int decimalPlaces)
        {
            double randomDec = random.NextDouble() * (maxValue - minValue) + minValue;
            return Convert.ToDecimal(randomDec.ToString($"n{decimalPlaces}"));
        }

        #endregion Customers
    }
}
