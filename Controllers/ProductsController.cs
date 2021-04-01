using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShoePortal_ECommerce.Data;
using OnlineShoePortal_ECommerce.Data.Entities;

namespace OnlineShoePortal_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {

        private readonly IShoeRepository _repository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IShoeRepository repository, ILogger<ProductsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                return Ok(_repository.GetAllProducts());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("Failed to get products");
            }
        }

        [HttpPost]
        [Produces("application/json")]
        public ActionResult Post(Product model)
        {
            return Ok();
        }

    }
}