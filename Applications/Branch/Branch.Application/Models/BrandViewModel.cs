using System;
using Branch.Domain.AggregatesModel.BrandAggregate;
using AutoMapper.Attributes;

namespace Branch.Application.Models
{
    [MapsFrom(typeof(Brand))]
    public class BrandViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [MapsFromProperty(typeof(Brand), "BrandDetail.JsonData")]
        public string JsonData { get; set; }
    }
}