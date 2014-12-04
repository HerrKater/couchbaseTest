namespace DomainModel
{
    public class Beer
    {
        public string type { get; set; }
        //public string docid { get; set; }

        public string name { get; set; }
        public string abv { get; set; }
        public string ibu { get; set; }
        public string srm { get; set; }
        public string upc { get; set; }

        public string brewery_id { get; set; }
        public string updated { get; set; }
        public string description { get; set; }
        public string style { get; set; }
        public string category { get; set; }
    }
}