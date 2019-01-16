using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shoestore.Models;
using shoestore.Repositories;

namespace shoestore.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ShoesController : ControllerBase
  {
    private readonly ShoeRepository _shoeRepo;
    public ShoesController(ShoeRepository repo)
    {
      _shoeRepo = repo;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
      return Ok(_shoeRepo.GetAll());
    }

    //GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Shoe> Get(int id)
    {
      Shoe result = _shoeRepo.GetById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }

    // // POST api/values
    // [HttpPost]
    // public ActionResult<Shoe> Post([FromBody] Shoe newshoe)
    // {
    //   return Ok(_shoeRepo.AddShoe(newshoe));
    // }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult<Shoe> Put(int id, [FromBody] Shoe value)
    {
      if (value.Id == 0)
      {
        value.Id = id;
      }
      Shoe result = _shoeRepo.EditShoe(id, value);
      if (result != null)
      {
        return Ok(result);
      }
      return NotFound();
    }

    // // DELETE api/values/5
    // [HttpDelete("{id}")]
    // public ActionResult<string> Delete(int id)
    // {
    //   if (_shoeRepo.DeleteShoe(id))
    //   {
    //     return Ok("Successfully Deleted Shoe");
    //   }
    //   return NotFound();
    // }
  }
}
