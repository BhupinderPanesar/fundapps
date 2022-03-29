using System;
using System.Collections.Generic;
using System.Linq;
using BucketNetting.Model;

namespace BucketNetting;

public class BucketHandler
{
    public List<Bucket> Handler(Portfolio portfolio)
    {
        List<Bucket> buckets = new List<Bucket>();
        buckets.Add(new Bucket {Id = 1, YearsUntilMaturity = "0-2", TotalFuture = 0});
        buckets.Add(new Bucket {Id = 2, YearsUntilMaturity = "2-7", TotalFuture = 0});
        buckets.Add(new Bucket {Id = 3, YearsUntilMaturity = "7-15", TotalFuture = 0});
        buckets.Add(new Bucket {Id = 4, YearsUntilMaturity = "15 >", TotalFuture = 0});

        foreach (var asset in portfolio.Assets)
        {
            if (asset.Class == "Future")
            {
                if(asset.MaturityDate.Year >= portfolio.DataDate.Year && asset.MaturityDate.Year < portfolio.DataDate.Year + 2)
                {
                    buckets.Find(bucket => bucket.Id == 1).TotalFuture += asset.MarketValue;
                }
                
                if(asset.MaturityDate.Year >= portfolio.DataDate.Year + 2 && asset.MaturityDate.Year < portfolio.DataDate.Year + 7)
                {
                    buckets.Find(bucket => bucket.Id == 2).TotalFuture += asset.MarketValue;
                }
                
                if(asset.MaturityDate.Year >= portfolio.DataDate.Year + 7 && asset.MaturityDate.Year < portfolio.DataDate.Year + 15)
                {
                    buckets.Find(bucket => bucket.Id == 3).TotalFuture += asset.MarketValue;
                }
                
                if(asset.MaturityDate.Year > portfolio.DataDate.Year + 15)
                {
                    buckets.Find(bucket => bucket.Id == 4).TotalFuture += asset.MarketValue;
                }
            }
        }

        return buckets;
    }
}