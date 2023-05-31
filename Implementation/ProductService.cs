﻿using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using Implementation.Interfaces;
using ModelsDto;

namespace Implementation
{
    public class ProductService : IProduct
    {
        private readonly IProductProvider _productProvider;

        public ProductService(IProductProvider productProvider)
        {
            _productProvider = productProvider;
        }

        public List<ProductDto> GetAllProducts()
        {
            List<Product> dbProducts = _productProvider.GetAllProducts();

            List<ProductDto> productResults = new();

            foreach (Product dbProduct in dbProducts)
            {
                ProductDto productDto = new()
                {
                    Id = dbProduct.Id,
                    Name = dbProduct.Name
                };
                productResults.Add(productDto);
            }
            return productResults;
        }
    }
}
