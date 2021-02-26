using System;
using System.Runtime.Serialization;
using MediatR;

namespace Product.Application.Commands
{
    [DataContract]
    public class UpdateProductCommand : IRequest<bool>
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

      public UpdateProductCommand()
      {       
      }

      public UpdateProductCommand(Guid Id, string Name, string Description, string JsonData, bool IsDisabled)
      {
          this.Id = Id;
          this.Name = Name;
          this.Description = Description;
          this.JsonData = JsonData;
          this.IsDisabled = IsDisabled;
      }   
    }
}