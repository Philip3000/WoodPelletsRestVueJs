using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RestWoodPellets.Repositories;
using WoodPelletsLib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestWoodPellets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WoodPelletController : ControllerBase
    {
        private readonly WoodPelletsRepository _repository;
        public WoodPelletController(WoodPelletsRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<WoodPelletController>
        [EnableCors("AllowAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<WoodPellet>> Get()
        {
            List<WoodPellet> woodPellets = _repository.GetAll();
            if (woodPellets == null) return NotFound("No Wood Pellet exist");
            return Ok(woodPellets);
        }

        // GET api/<WoodPelletController>/5
        [EnableCors("AllowAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<WoodPellet> Get(int id)
        {
            WoodPellet woodPellet = _repository.GetById(id);
            if (woodPellet == null) return NotFound("No such id" + id);
            return Ok(woodPellet);
        }

        // POST api/<WoodPelletController>
        [EnableCors("AllowAll")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<WoodPellet> Post([FromBody] WoodPellet value)
        {
            try
            {
                WoodPellet createdPellet = _repository.Add(value);
                return Created($"api/WoodPelletController/{createdPellet.Id}", createdPellet);
            }
            catch (ArgumentException n)
            {
                return BadRequest(n.Message);
            }
        }
        [EnableCors("AllowAll")]
        // PUT api/<WoodPelletController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPut("{id}")]
        public ActionResult<WoodPellet> Put(int id, [FromBody] WoodPellet value)
        {
            try
            {
                WoodPellet updatedWoodPellet = _repository.Update(id, value);
                return Ok(updatedWoodPellet);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [EnableCors("AllowAll")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // DELETE api/<WoodPelletController>/5
        [HttpDelete("{id}")]
        public ActionResult<WoodPellet> Delete(int id)
        {
            WoodPellet deletedPellet = _repository.Delete(id);
            if (deletedPellet == null) return NotFound("No pellet deleted, id does not exist. Id:" + id);
            return Ok(deletedPellet);
        }
    }
}

