using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MongoDataAccess.API.Infrastructure.Repositories;
using MongoDataAccess.API.Models;

namespace MongoDataAccess.API.Services
{
    public class ProductServices : IProductServices
    {
        private IMongoDbRepository<Product> _productRepository;
        private readonly ILogger<IProductServices> _logger;

        public ProductServices(
            IMongoDbRepository<Product> productRepository,
            ILogger<IProductServices> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var query = _productRepository.GetAll();
            return query;
        }
    }
}