using System;
using System.Runtime.Serialization;
using MediatR;

namespace Branch.Application.Commands
{
    [DataContract]
    public class UpdateBranchCommand : IRequest<bool>
    {
      [DataMember]
      public Guid Id { get; set; }

      [DataMember]
      public string Name { get; private set; }

      [DataMember]
      public string Description { get; private set; }

      [DataMember]
      public string JsonData { get; private set; }

      [DataMember]
      public bool IsDisabled { get; private set; }

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

      public UpdateBranchCommand()
      {       
      }

      public UpdateBranchCommand(Guid id, string name, string description, string jsonData, bool isDisabled, string street, 
        string city, string state, string country, string zipcode)
      {
          Id = id;
          Name = name;
          Description = description;
          JsonData = jsonData;
          IsDisabled = isDisabled;
          Street = street;
          City = city;
          State = state;
          Country = country;
          ZipCode = zipcode;
      }   
    }
}