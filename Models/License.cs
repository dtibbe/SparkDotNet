using System;
using Newtonsoft.Json;

namespace SparkDotNet {
    public class License
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TotalUnits { get; set; }
        public string ConsumedUnits { get; set; }
        public string SubscriptionId { get; set; }
        public string SiteUrl { get; set; }
        public string SiteType { get; set; }

        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}