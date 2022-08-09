using API.SocityManager.Handlers;
using API.SocityManager.Models;
using BLL.SocityManager.Entities;
using Common.SocityManager.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.SocityManager.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingRepository<Building> _repository;

        public BuildingController(IBuildingRepository<Building> repository)
        {
            this._repository = repository;
        }
        // GET: api/<BuildingController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Building>> Get()
        {
            return Ok(_repository.Get());
        }

        // GET api/<BuildingController>/5
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Building> Get(Guid id)
        {
            try
            {
                Building? currentBuilding = _repository.Get(id);
                if (currentBuilding == null) throw new Exception();
                return Ok(currentBuilding);
            }
            catch (Exception)
            {
                return NotFound(new { Id = id });
            }
        }

        // POST api/<BuildingController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult Post(BuildingInsert value)
        {
            Guid newId = _repository.Insert(value.ToBuilding());
            return CreatedAtAction(nameof(Get), new { id = newId }, newId);
        }

        // PUT api/<BuildingController>/5
        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Put(Guid id, BuildingUpdate value)
        {
            try
            {
                if (_repository.Get(id) is null) throw new Exception();
                _repository.Update(id, value.ToBuilding());
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound(new { id = id });
            }
        }

        // DELETE api/<BuildingController>/5
        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(Guid id)
        {
            try
            {
                if (_repository.Get(id) is null) throw new Exception();
                _repository.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound(new { id = id });
            }
        }
    }
}
