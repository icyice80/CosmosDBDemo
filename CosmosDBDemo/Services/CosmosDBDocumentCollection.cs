using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmosDBDemo.Model;
using Microsoft.Azure.Documents.Client;

namespace CosmosDBDemo.Services
{
    public class CosmosDBDocumentCollection<T> where T : Transaction
    {
        #region Fields
        private readonly DocumentClient _client;

        private readonly Uri _collectionUri;
        #endregion

        #region Constructor
        public CosmosDBDocumentCollection(DocumentClient client, string databaseId, string collectionId)
        {
            _client = client;
            _collectionUri = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);
        }
        #endregion

        #region Methods

        //TODO: two methods

        public Transaction Get(string id)
        {
            return null;
        }


        public IQueryable<T> GetTransactions()
        {
            return null;
        }

        #endregion
    }
}
