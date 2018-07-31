using System.Threading.Tasks;
using CosmosDBDemo.Model;
using CosmosDBDemo.Request;
using CosmosDBDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CosmosDBDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly EosCosmosDBClient _client;
        public TransactionController(EosCosmosDBClient client)
        {
            _client = client;
        }

        [HttpGet("{id}")]
        public async Task<string> Get(string id)
        {
            var result = JsonConvert.SerializeObject(await _client.Transactions.Get(id));
            return result;
        }

        [HttpPost]
        public Task<PageResult<Transaction>> Post([FromBody] PageRequest request)
        {
            return _client.Transactions.GetList(request.Token, request.PageSize);
        }
    }
}
