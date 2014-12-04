using System;
using System.Linq;
using Couchbase;
using Couchbase.Configuration;
using Couchbase.Extensions;
using Couchbase.Operations;
using DomainModel;
using System.Collections.Generic;
using Enyim.Caching.Memcached;
using Newtonsoft.Json;

namespace DAL
{
    public class BeerRepository
    {
        public string serverUri { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

        public List<Beer> GetBeers()
        {
            var client = getCouchbaseClient();

            var view = client.GetView<Beer>("dev_beer_view", "beer_view");

           
            
            var result = view.GetPagedView(10, "name", "name");

            while (result.MoveNext())
            {
                var bsd = result.ToList();

                Console.WriteLine(bsd.First().name);
            }
            return view.ToList();
        }

        public Beer GetBeerByID(string id)
        {
            throw new NotImplementedException();

        }

        public bool CreateBeer(Beer beer)
        {
            var client = getCouchbaseClient();

            if (!client.KeyExists("beer::count"))
            {
                client.ExecuteStore(StoreMode.Set, "beer::count", 5891, PersistTo.Zero);
            }
            var count = client.Increment("beer::count", 1, 1);

            client.ExecuteStore(StoreMode.Set, "test_beer_" + count, serialize(new Beer()
            {
                type = "beer",

            }), PersistTo.Zero);
            return true;

        }


        public bool UpdateBeer(Beer beer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBeer(string id)
        {
            throw new NotImplementedException();
        }

        private CouchbaseClient getCouchbaseClient()
        {
            var config = new CouchbaseClientConfiguration()
            {
                Bucket = "beer-sample",
                Username = "Administrator",
                Password = "Q1w2e3r4",

            };
            config.Urls.Add(new Uri("http://localhost:8091/pools"));

            return new CouchbaseClient(config);

        }

        public static string serialize(object o)
        {
            return JsonConvert.SerializeObject(o);
        }
    }
}
