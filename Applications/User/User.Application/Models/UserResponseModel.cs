using System;
using AutoMapper;
using AutoMapper.Attributes;

namespace User.Application.Models
{
    [MapsFrom(typeof(Domain.AggregatesModel.UserAggregate.User))]
    public class UserResponseModel
    {
        public Guid Id { get; set; } 
        public string Username { get; set; }
        public string Mail { get; set; }
        public AdressViewModel Address { get; set; }
    }

    public class AdressViewModel
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}