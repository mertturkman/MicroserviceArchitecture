using System;
using System.Collections.Generic;
using Branch.Domain.SeedWork;

namespace Branch.Domain.AggregatesModel.BrandAggregate
{
    public class BrandDetail:Entity 
    {
        public string JsonData { get; set; }
        Brand Brand { get; set; }

        public BrandDetail ()
        { }

        public BrandDetail(string jsonData) 
        {
            JsonData = jsonData;
        }

        public BrandDetail(Guid id, string jsonData, Brand brand) 
        {
            Id = id;
            JsonData = jsonData;
            Brand = brand;
        }
    }
}