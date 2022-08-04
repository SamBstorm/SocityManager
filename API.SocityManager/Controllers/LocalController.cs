using API.SocityManager.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.SocityManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalController : ControllerBase
    {
        private static List<Local> _locals = new List<Local>
        {
            new Local(){Id = 1, BuildingId=1, BuildingFloor= 1, Name="A11", Surface=14, HaveAirCo=true, HaveProjector=true, WorkStationCount = 5},
            new Local(){Id = 2, BuildingId=1, BuildingFloor= 1, Name="A12", Surface=5.8, HaveAirCo=false, HaveProjector=false, WorkStationCount = 2},
            new Local(){Id = 3, BuildingId=2, BuildingFloor= 1, Name="B11", Surface=10, HaveAirCo=true, HaveProjector=false, WorkStationCount = 5},
            new Local(){Id = 4, BuildingId=2, BuildingFloor= 1, Name="B12", Surface=20, HaveAirCo=true, HaveProjector=true, WorkStationCount = 8},
            new Local(){Id = 5, BuildingId=2, BuildingFloor= 2, Name="B21", Surface=22, HaveAirCo=false, HaveProjector=true, WorkStationCount = 8},
        };
        // GET: api/<LocalController>
        [HttpGet()]
        public ActionResult<IEnumerable<Local>> Get()
        {
            return Ok(_locals);
        }

        // GET api/<LocalController>/5
        [HttpGet("{id:int:min(1)}")]
        public ActionResult<Local> Get(int id)
        {
            try
            {
                Local? currentLocal = _locals.Find(l => l.Id == id);
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
        public ActionResult<int> Post(Local newLocal)
        {
            int maxId = _locals.Max(l => l.Id);
            newLocal.Id = maxId + 1;
            _locals.Add(newLocal);
            return CreatedAtAction(nameof(Get),new { id = newLocal.Id },newLocal.Id);
        }

        // PUT api/<LocalController>/5
        [HttpPut("{id:int:min(1)}")]
        public ActionResult Put(int id, Local newLocal)
        {

            try
            {
                Local? currentLocal = _locals.Find(l => l.Id == id);
                if (currentLocal is null) throw new Exception();
                currentLocal.Name = newLocal.Name;
                currentLocal.BuildingId = newLocal.BuildingId;
                currentLocal.BuildingFloor = newLocal.BuildingFloor;
                currentLocal.Surface = newLocal.Surface;
                currentLocal.HaveAirCo = newLocal.HaveAirCo;
                currentLocal.HaveProjector = newLocal.HaveProjector;
                currentLocal.WorkStationCount = newLocal.WorkStationCount;
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<LocalController>/5
        [HttpDelete("{id:int:min(1)}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Local? currentLocal = _locals.Find(l => l.Id == id);
                if (currentLocal is null) throw new Exception();
                _locals.Remove(currentLocal);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
