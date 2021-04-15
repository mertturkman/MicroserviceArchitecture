using System;
using System.Collections.Generic;
using CrossCutting.Events.User;
using User.Domain.SeedWork;

namespace User.Domain.AggregatesModel.UserAggregate {
    public class User : Entity, IAggregateRoot {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public DateTime? PasswordUpdateDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public int FailedLoginAttempts { get; set; }
        public DateTime? LastFailedLoginAttemptDate { get; set; }
        public Address Address { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UserToken> UserTokens { get; set; }

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

            AddIntegrationEvent(new Register(Mail, Name, Surname));
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

        public void FailedLoginAttempt(int failedLoginAttemptsLimit)
        {
            if (FailedLoginAttempts < failedLoginAttemptsLimit)
            {
                FailedLoginAttempts = FailedLoginAttempts + 1;
                LastFailedLoginAttemptDate = DateTime.UtcNow;
            }
        }
        
        public void SuccessLoginAttempt()
        {
            FailedLoginAttempts = 0;
            LastLoginDate = DateTime.UtcNow;
        }

        public bool IsLoginBlocked(int failedLoginAttemptTimeout, int failedLoginAttemptsLimit)
        {
            return FailedLoginAttempts >= 3
                   && LastFailedLoginAttemptDate.HasValue
                   && LastFailedLoginAttemptDate.Value.AddMinutes(failedLoginAttemptTimeout) > DateTime.UtcNow;
        }
        
    }
}