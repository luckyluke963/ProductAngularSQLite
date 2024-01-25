using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly StoreContext _storeContext;

        public ProductController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProduct()
        {
            var getProduct = await _storeContext.Products.ToListAsync();
            return Ok(getProduct);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductId(int id)
        {
            var GetProductId = await _storeContext.Products.FindAsync(id);
            return Ok(GetProductId);
        }
    }
}