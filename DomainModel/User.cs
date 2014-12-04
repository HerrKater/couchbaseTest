using System;

namespace DomainModel
{
    public class User:CouchbaseDocument
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
