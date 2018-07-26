using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private const string TransactionCollectionId = "esocollection";


        #region Properties

        public CosmosDBDocumentCollection<Transaction> Transactions { get; }

        #endregion

        public EosCosmosDBClient(IOptions<CosmosDBOptions> options)
        {
            _options = options.Value;
            _client = new DocumentClient(new Uri(_options.EndpointUri), _options.PrimaryKey);
            Transactions = new CosmosDBDocumentCollection<Transaction>(_client,_options.DatabaseId,TransactionCollectionId);
        }
    }
}
