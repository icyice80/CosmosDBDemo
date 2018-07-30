using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosDBDemo.Model
{
    public class PageResult<T>
    {

        public PageResult()
        {
            this.Results = new List<T>();
        }
        public IList<T> Results { get; set; }

        public string ContinuationToken { get; set; }


        public bool HasMore { get; set; }
    }
}
