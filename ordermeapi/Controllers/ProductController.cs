using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ordermeapi.Entities;
using ordermeapi.Repository;

namespace ordermeapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       public IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var results = _repo.Products();
                return Ok(results);


            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get product");
            }
        }



        public ActionResult<IEnumerable<string>> GetProductsForMobile()
        {
            try
            {
                var results = _repo.ProductMobileResult().ToList();
                return Ok(results);


            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get product");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProduct(int id)
        {

            try
            {
                var results = _repo.GetProductById(id);

                return Ok(results);
            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get brand");
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody]Product model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    model.ProductCategoryId = model.CategoryId;
                    _repo.SaveProduct(model);
                    return Ok();
                }
                else
                {
                    return BadRequest("I couldnot save the product");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody]Product model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    return Ok(_repo.UpdateProduct(id, model));

                }
                else
                {
                    return BadRequest("I couldnot update");
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {

            try
            {
                _repo.DeleteProduct(id);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest("Failed to delete the product");
            }
        }


    }
}