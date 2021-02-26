using System;
using System.Runtime.Serialization;
using MediatR;

namespace Product.Application.Commands
{
    [DataContract]
    public class CreateProductCommand : IRequest<bool>
    {
      [DataMember]
      public Guid BranchId { get; private set; }

      [DataMember]
      public string Name { get; private set; }

      [DataMember]
      public string Description { get; private set; }

      [DataMember]
      public string JsonData { get; private set; }

      public CreateProductCommand()
      {       
      }

      public CreateProductCommand(Guid BranchId, string Name, string Description, string JsonData)
      {
          this.BranchId = BranchId;
          this.Name = Name;
          this.Description = Description;
          this.JsonData = JsonData;
      }   
    }
}