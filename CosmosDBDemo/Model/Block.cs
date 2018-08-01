using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CosmosDBDemo.Model
{
    public class Block
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("block_num")]
        public string BlockNumber { get; set; }

    }
}
