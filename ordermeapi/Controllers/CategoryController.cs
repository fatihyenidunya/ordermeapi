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
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public ICategoryRepository _repo;

        public CategoryController(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var results = _repo.Categories();
                return Ok(results);


            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get category");
            }
        }


        [HttpGet("{id:int}")]
        public IActionResult GetCategory(int id)
        {

            try
            {
                var results = _repo.GetCategoryById(id);

                return Ok(results);
            }
            catch (Exception ex)
            {

                return BadRequest("Failed to get category");
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody]Category model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.SaveCategory(model);
                    return Ok();
                }
                else
                {
                    return BadRequest("I couldnot save the category");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody]Category model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    return Ok(_repo.UpdateCategory(id, model));

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
                _repo.DeleteCategory(id);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest("Failed to delete the category");
            }
        }

    }
}