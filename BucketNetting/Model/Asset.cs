using System;

namespace BucketNetting.Model
{
    public class Asset
    {
        public string Id { get; set; }
        public string Class { get; set; }
        public decimal MarketValue { get; set; }
        public DateTime MaturityDate { get; set; }
    }
}