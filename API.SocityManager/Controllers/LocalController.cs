using API.SocityManager.Handlers;
using API.SocityManager.Models;
using BLL.SocityManager.Entities;
using Common.SocityManager.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.SocityManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalController : ControllerBase
    {
        private readonly ILocalRepository<Local> _localRepository;

        public LocalController(ILocalRepository<Local> localRepository)
        {
            _localRepository = localRepository;
        }

        // GET: api/<LocalController>
        [HttpGet()]
        public ActionResult<IEnumerable<Local>> Get()
        {
            return Ok(_localRepository.Get());
        }

        // GET api/<LocalController>/5
        [HttpGet("{id:Guid}")]
        public ActionResult<Local> Get(Guid id)
        {
            try
            {
                Local? currentLocal = _localRepository.Get(id);
                if (currentLocal == null) throw new Exception();
                return Ok(currentLocal);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<LocalController>
        [HttpPost()]
        [Authorize]
        public ActionResult<int> Post(LocalCreate newLocal)
        {
            Guid newId = _localRepository.Insert(newLocal.ToLocal());
            return CreatedAtAction(nameof(Get),new { id = newId }, newId);
        }

        // PUT api/<LocalController>/5
        [Authorize]
        [HttpPut("{id:Guid}")]
        public ActionResult Put(Guid id, Local newLocal)
        {

            try
            {
                if (_localRepository.Get(id) is null) throw new Exception();
                _localRepository.Update(id, newLocal);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<LocalController>/5
        [Authorize]
        [HttpDelete("{id:Guid}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                Local? currentLocal = _localRepository.Get(id);
                if (currentLocal is null) throw new Exception();
                _localRepository.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
