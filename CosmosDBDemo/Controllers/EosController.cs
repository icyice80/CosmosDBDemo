using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmosDBDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CosmosDBDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EosController : ControllerBase
    {
        private readonly EosCosmosDBClient _client;
        public EosController(EosCosmosDBClient client)
        {
            _client = client;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(string id)
        {
            return JsonConvert.SerializeObject(_client.Transactions.Get(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
