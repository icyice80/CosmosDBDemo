using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmosDBDemo.Model;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace CosmosDBDemo.Services
{
    public class CosmosDBDocumentCollection
    {
        #region Fields
        private readonly DocumentClient _client;
        private readonly string _databaseId;
        private readonly string _collectionId;    
        private readonly Uri _collectionUri;
        #endregion

        #region Constructor
        public CosmosDBDocumentCollection(DocumentClient client, string databaseId, string collectionId)
        {
            this._client = client;
            this._databaseId = databaseId;
            this._collectionId = collectionId;
            this._collectionUri = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);
        }
        #endregion

        #region Methods

        public async Task<Document> Get(string id)
        {
            return await _client.ReadDocumentAsync(UriFactory.CreateDocumentUri(this._databaseId,this._collectionId,id));
        }


        public async Task<PageResult> GetList(string continuationToken, int pageSize)
        {
            var feedOptions = new FeedOptions {MaxItemCount = pageSize, RequestContinuation = continuationToken};

            var transactions = this._client.CreateDocumentQuery(this._collectionUri, feedOptions).AsDocumentQuery();

            var result = new PageResult();

            if (transactions.HasMoreResults)
            {
                var list = await transactions.ExecuteNextAsync();
                result.ContinuationToken = list.ResponseContinuation;

                if (!string.IsNullOrWhiteSpace(result.ContinuationToken))
                {
                    result.HasMore = true;
                }

                result.Results = list;
            }
           
            return result;
        }

        #endregion
    }
}
