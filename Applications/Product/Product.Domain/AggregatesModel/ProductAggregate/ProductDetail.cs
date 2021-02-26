using System;
using System.Collections.Generic;
using Product.Domain.SeedWork;

namespace Product.Domain.AggregatesModel.ProductAggregate
{
    public class ProductDetail:Entity 
    {
        public string JsonData { get; set; }
        Product Product { get; set; }

        public ProductDetail ()
        { }

        public ProductDetail(string jsonData) 
        {
            JsonData = jsonData;
        }

        public ProductDetail(Guid id, string jsonData, Product product) 
        {
            Id = id;
            JsonData = jsonData;
            Product = product;
        }
    }
}