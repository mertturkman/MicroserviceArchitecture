using System;
using Product.Domain.AggregatesModel.BranchAggregate;
using AutoMapper.Attributes;

namespace Product.Application.Models
{
    [MapsFrom(typeof(Product.Domain.AggregatesModel.ProductAggregate.Product))]
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [MapsFromProperty(typeof(Branch), "BranchDetail.JsonData")]
        public string JsonData { get; set; }
        public BranchData Branch { get; set; }
    }

    [MapsFrom(typeof(Branch))]
    public class BranchData {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}