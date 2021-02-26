using AutoMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using User.Domain.AggregatesModel.PermissionAggregate;

namespace User.Application.Models
{
    [MapsFrom(typeof(Permission))]
    public class PermissionResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
