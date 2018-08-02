namespace CosmosDBDemo.Model
{
    public class PageResult
    {
        public dynamic Results { get; set; }

        public string ContinuationToken { get; set; }

        public bool HasMore { get; set; }
    }
}
