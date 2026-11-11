using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<MusicRecordModel> Get()
        {
            return recordRepo.GetAll();
        }

        // GET api/<MusicRecordsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MusicRecordsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MusicRecordsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MusicRecordsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
