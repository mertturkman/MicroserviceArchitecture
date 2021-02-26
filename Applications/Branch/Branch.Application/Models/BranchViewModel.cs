using System;
using Branch.Domain.AggregatesModel.BrandAggregate;
using AutoMapper.Attributes;

namespace Branch.Application.Models
{
    [MapsFrom(typeof(Branch.Domain.AggregatesModel.BranchAggregate.Branch))]
    public class BranchViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [MapsFromProperty(typeof(Branch.Domain.AggregatesModel.BranchAggregate.Branch), "BranchDetail.JsonData")]
        public string JsonData { get; set; }
        public BrandData Brand { get; set; }
    }

    [MapsFrom(typeof(Brand))]
    public class BrandData {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}