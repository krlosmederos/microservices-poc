using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDataAccess.API.Models;
using MongoDataAccess.API.Services;
using MongoDataAccess.API.Settings;

namespace MongoDataAccess.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductServices _productServices;

        public ProductsController(
            ILogger<ProductsController> logger,
            IProductServices productServices)
        {
            _logger = logger;
            _productServices = productServices;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productServices.GetAllProducts();
            return Ok(products);
        }
    }
}
