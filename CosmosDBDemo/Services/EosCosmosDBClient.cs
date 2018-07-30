using System;
using CosmosDBDemo.Model;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Options;

namespace CosmosDBDemo.Services
{
    public class EosCosmosDBClient
    {
        private readonly CosmosDBOptions _options;
        private readonly DocumentClient _client;
        //TODO:
        private const string TransactionCollectionId = "transactions";
        private const string BlockCollectionId = "blocks";

        #region Properties

        public CosmosDBDocumentCollection<Transaction> Transactions { get; }

        public CosmosDBDocumentCollection<Block> Blocks { get; }

        #endregion

        public EosCosmosDBClient(IOptions<CosmosDBOptions> options)
        {
            _options = options.Value;
            _client = new DocumentClient(new Uri(_options.EndpointUri), _options.PrimaryKey);
            Transactions = new CosmosDBDocumentCollection<Transaction>(_client,_options.DatabaseId, TransactionCollectionId);
            Blocks = new CosmosDBDocumentCollection<Block>(_client, _options.DatabaseId, BlockCollectionId);
        }
    }
}
