namespace DomainModel
{
    public class CouchbaseDocument
    {
        public string type { get { return GetType().Name; } }
        public string id { get; set; }
    }
}