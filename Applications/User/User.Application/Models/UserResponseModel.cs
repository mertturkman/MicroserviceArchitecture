using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Attributes;

namespace User.Application.Models
{
    public class UserResponseModel
    {
        public Guid Id { get; set; } 
        public string Username { get; set; }
        public string Mail { get; set; }
        public AdressViewModel Address { get; set; }

        public UserResponseModel MapToResponse(Domain.AggregatesModel.UserAggregate.User user)
        {
            Id = user.Id;
            Username = user.Username;
            Mail = user.Mail;

            Address = new AdressViewModel();
            Address.City = user.Address.City;
            Address.Country = user.Address.Country;
            Address.State = user.Address.State;
            Address.Street = user.Address.Street;
            Address.ZipCode = user.Address.ZipCode;

            return this;
        }
        
        public UserResponseModel[] MapToResponse(Domain.AggregatesModel.UserAggregate.User[] users)
        {
            List<UserResponseModel> userResponseModels = new List<UserResponseModel>();

            foreach(var userItem in users)
            {
                UserResponseModel userResponseModel = new UserResponseModel();

                userResponseModel.Id = userItem.Id;
                userResponseModel.Username = userItem.Username;
                userResponseModel.Mail = userItem.Mail;

                userResponseModel.Address = new AdressViewModel();
                userResponseModel.Address.City = userItem.Address.City;
                userResponseModel.Address.Country = userItem.Address.Country;
                userResponseModel.Address.State = userItem.Address.State;
                userResponseModel.Address.Street = userItem.Address.Street;
                userResponseModel.Address.ZipCode = userItem.Address.ZipCode;

                userResponseModels.Add(userResponseModel);
            }

            return userResponseModels.ToArray();
        }

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