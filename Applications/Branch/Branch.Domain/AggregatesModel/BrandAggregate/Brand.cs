using System;
using Branch.Domain.SeedWork;
using System.Collections.Generic;
using Branch.Domain.AggregatesModel.BranchAggregate;

namespace Branch.Domain.AggregatesModel.BrandAggregate
{
    public class Brand:Entity, IAggregateRoot 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDisabled { get; set; }
        public BrandDetail BrandDetail { get; set; }
        public Address Address { get; set; }
        public ICollection<Branch.Domain.AggregatesModel.BranchAggregate.Branch> Branches { get; set; }

        

        public Brand ()
        { }

        public Brand(string name, string description, bool isDisabled) 
        {
            Name = name;
            Description = description;
            IsDisabled = isDisabled;
        }
        
        public Brand(string name, string description,  bool isDisabled, Address address, BrandDetail brandDetail) 
        {
            Name = name;
            Description = description;
            IsDisabled = isDisabled;
            Address = Address;
            BrandDetail = brandDetail;
        }

        public Brand(string name, string description,  bool isDisabled, Address address, BrandDetail brandDetail, 
            List<Branch.Domain.AggregatesModel.BranchAggregate.Branch> branches) 
        {
            Name = name;
            Description = description;
            IsDisabled = isDisabled;
            Address = Address;
            BrandDetail = brandDetail;
            Branches = branches;
        }

        public Brand(Guid id, string name, string description,  bool isDisabled, BrandDetail brandDetail, 
            List<Branch.Domain.AggregatesModel.BranchAggregate.Branch> branches) 
        {
            Id = id;
            Name = name;
            Description = description;
            IsDisabled = isDisabled;
            BrandDetail = brandDetail;
            Branches = branches;
        }

        public void Update(string name, string description,  bool isDisabled, Address address, string jsonData) 
        {
            Name = name;
            Description = description;
            IsDisabled = isDisabled;
            Address = address;
            BrandDetail.JsonData = jsonData;
        }
    }
}