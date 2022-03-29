using System;
using System.Linq;
using BucketNetting.Model;
using FluentAssertions;
using Xunit;

namespace BucketNetting.Tests
{
    public class BucketNettingTests
    {
        public static Portfolio SampleData = new Portfolio
        {
            DataDate = new DateTime(2017, 06, 30),
            Assets = new[]
            {
                new Asset {Id = "Equity1", Class = "Equity", MarketValue = 10000},
                new Asset {Id = "Future1", Class = "Future", MarketValue = 20000,  MaturityDate = new DateTime(2018, 12, 30)},
                new Asset {Id = "Equity2", Class = "Equity", MarketValue = 5000},
                new Asset {Id = "Future2", Class = "Future", MarketValue = -15000, MaturityDate = new DateTime(2017, 12, 30)},
                new Asset {Id = "Future3", Class = "Future", MarketValue = -30000, MaturityDate = new DateTime(2020, 12, 30)},
                new Asset {Id = "Future4", Class = "Future", MarketValue = 10000,  MaturityDate = new DateTime(2023, 12, 30)},
                new Asset {Id = "Future5", Class = "Future", MarketValue = 20000,  MaturityDate = new DateTime(2029, 12, 30)},
                new Asset {Id = "Equity3", Class = "Equity", MarketValue = 3000},
                new Asset {Id = "Future6", Class = "Future", MarketValue = 20000,  MaturityDate = new DateTime(2038, 12, 30)}
            }
        };


        [Fact]
        public void BucketsHaveTotalFutureValues()
        {
            Portfolio MockData = new Portfolio
            {
                DataDate = new DateTime(2000, 1, 1),
                Assets = new Asset[]
                {
                    new Asset {Id = "1", Class = "Future", MarketValue = 1000, MaturityDate = new DateTime(2001, 1, 1)},
                    new Asset {Id = "2", Class = "Future", MarketValue = 5000, MaturityDate = new DateTime(2004, 1, 1)}
                }
            };
            
            var bucketHandler = new BucketHandler();
            var buckets = bucketHandler.Handler(MockData);

            buckets[0].TotalFuture.Should().Be(MockData.Assets[0].MarketValue);
            buckets[1].TotalFuture.Should().Be(MockData.Assets[1].MarketValue);
        }
    }
}