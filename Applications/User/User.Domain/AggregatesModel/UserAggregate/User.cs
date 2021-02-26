using System;
using System.Collections.Generic;
using CrossCutting.Events.User;
using User.Domain.AggregatesModel.RoleAggregate;
using User.Domain.SeedWork;

namespace User.Domain.AggregatesModel.UserAggregate {
    public class User : Entity, IAggregateRoot {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public DateTime? PasswordUpdateDate { get; set; }
        public Address Address { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }

        public User() { }
        
        public User(string name, string surname, string username, string password, string mail, Address address) 
        {
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
            Mail = mail;
            Address = address;
            PasswordUpdateDate = DateTime.UtcNow;

            AddIntegrationEvent(new Register(Username, Mail, Name, Surname));
        }

        public void SetInformation(string name, string surname, string mail, string street, string city, string state, 
            string country, string zipcode)
        {
            Name = name;
            Surname = surname;
            Mail = mail;
            Address.Street = street;
            Address.State = state;
            Address.City = city;
            Address.Country = country;
            Address.ZipCode = zipcode;
        }

        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}