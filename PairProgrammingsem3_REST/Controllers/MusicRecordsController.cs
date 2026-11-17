using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PairProgrammingsem3_REST.Interfaces;
using PairProgrammingsem3_REST.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PairProgrammingsem3_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicRecordsController : ControllerBase
    {
        private readonly IMusicRecordRepository recordRepo;
        public MusicRecordsController(IMusicRecordRepository repo)
        {
            recordRepo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public IEnumerable<MusicRecord> Get(
            [FromQuery] string title,
            [FromQuery] string artist)
        {
            return recordRepo.GetAll(title, artist);
        }

        // GET api/<MusicRecordsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public MusicRecord Get(int id)
        {
            return recordRepo.Read(id);
        }

        // POST api/<MusicRecordsController>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public MusicRecord Post([FromBody] MusicRecord value)
        {
            return recordRepo.Add(value);
        }

        // PUT api/<MusicRecordsController>/5
        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MusicRecordsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public MusicRecord Delete(int id)
        {
            MusicRecord record = recordRepo.Read(id);
            recordRepo.Delete(id);
            return record;

        }
    }
}
