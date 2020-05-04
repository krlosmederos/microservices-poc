using System.Collections.Generic;
using MongoDataAccess.API.Models;

namespace MongoDataAccess.API.Services
{
    public interface IProductServices
    {
        IEnumerable<Product> GetAllProducts();
    }
}