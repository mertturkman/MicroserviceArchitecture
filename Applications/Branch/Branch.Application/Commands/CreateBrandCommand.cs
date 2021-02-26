using System;
using System.Runtime.Serialization;
using MediatR;

namespace Branch.Application.Commands
{
    [DataContract]
    public class CreateBrandCommand : IRequest<bool>
    {
      [DataMember]
      public string Name { get; private set; }

      [DataMember]
      public string Description { get; private set; }

      [DataMember]
      public string JsonData { get; private set; }

      [DataMember]
      public string Street { get; private set; }

      [DataMember]
      public string City { get; private set; }

      [DataMember]
      public string State { get; private set; }

      [DataMember]
      public string Country { get; private set; }

      [DataMember]
      public string ZipCode { get; private set; }

      public CreateBrandCommand()
      {       
      }

      public CreateBrandCommand(string name, string description, string jsonData, string street, string city, string state, 
        string country, string zipcode)
      {
          Name = name;
          Description = description;
          JsonData = jsonData;
          Street = street;
          City = city;
          State = state;
          Country = country;
          ZipCode = zipcode;
      }   
    }
}