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
        public MusicRecord Get(int id)
        {
            return recordRepo.Read(id);
        }

        // POST api/<MusicRecordsController>
        [HttpPost]
        public MusicRecord Post([FromBody] MusicRecord value)
        {
            return recordRepo.Add(value);
        }

        // PUT api/<MusicRecordsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MusicRecordsController>/5
        [HttpDelete("{id}")]
        public MusicRecord Delete(int id)
        {
            MusicRecord record = recordRepo.Read(id);
            recordRepo.Delete(id);
            return record;

        }
    }
}
