using System.Threading.Tasks;
using CosmosDBDemo.Model;
using CosmosDBDemo.Request;
using CosmosDBDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;

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
        public Task<Document> Get(string id)
        {
            return _client.Transactions.Get(id);
        }

        [HttpPost]
        public Task<PageResult> Post([FromBody] PageRequest request)
        {
            return _client.Transactions.GetList(request.Token, request.PageSize);
        }
    }
}
