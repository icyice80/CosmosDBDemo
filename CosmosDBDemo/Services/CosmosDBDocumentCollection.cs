using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CosmosDBDemo.Model;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace CosmosDBDemo.Services
{
    public class CosmosDBDocumentCollection<T> where T : class
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

        public async Task<T> Get(string id)
        {
            return await _client.ReadDocumentAsync<T>(UriFactory.CreateDocumentUri(this._databaseId,this._collectionId,id));
        }


        public async Task<PageResult<T>> GetList(string continuationToken, int pageSize)
        {
            var feedOptions = new FeedOptions {MaxItemCount = pageSize, RequestContinuation = continuationToken};

            var transactions = this._client.CreateDocumentQuery(this._collectionUri, feedOptions).AsDocumentQuery();

            var result = new PageResult<T>();

            if (transactions.HasMoreResults)
            {
                var list = await transactions.ExecuteNextAsync<T>();
                result.ContinuationToken = list.ResponseContinuation;

                if (!string.IsNullOrWhiteSpace(result.ContinuationToken))
                {
                    result.HasMore = true;
                }

                ((List<T>)result.Results).AddRange(list);
            }
           
            return result;
        }

        #endregion
    }
}
