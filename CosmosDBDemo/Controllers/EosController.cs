using System.Threading.Tasks;
using CosmosDBDemo.Model;
using CosmosDBDemo.Request;
using CosmosDBDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace CosmosDBDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockController : ControllerBase
    {
        private readonly EosCosmosDBClient _client;
        public BlockController(EosCosmosDBClient client)
        {
            _client = client;
        }
        
        public Task<Block> Get(string id)
        {
            return _client.Blocks.Get(id);
        }

        [HttpPost]
        public Task<PageResult<Block>> Query(PageRequest request)
        {
            return _client.Blocks.GetList(request.Token, request.PageSize);
        }
    }
}
