using System.Collections.Generic;
using System.Threading.Tasks;
using FaceRecog.Web.API.Services.FaceRecognition;
using Microsoft.AspNetCore.Mvc;

namespace FaceRecog.Web.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IFaceRecognitionClient _client;
        public ValuesController(IFaceRecognitionClient client)
        {
            _client = client;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            await _client.Test();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
