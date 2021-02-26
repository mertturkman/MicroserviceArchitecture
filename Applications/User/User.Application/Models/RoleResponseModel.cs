using System;
using User.Domain.AggregatesModel.RoleAggregate;
using AutoMapper.Attributes;

namespace User.Application.Models
{
    [MapsFrom(typeof(Role))]
    public class RoleResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}