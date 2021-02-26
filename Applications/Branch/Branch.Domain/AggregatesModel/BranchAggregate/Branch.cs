using System;
using Branch.Domain.SeedWork;
using Branch.Domain.AggregatesModel.BrandAggregate;

namespace Branch.Domain.AggregatesModel.BranchAggregate
{
    public class Branch:Entity, IAggregateRoot
    { 
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDisabled { get; set; }
        public Brand Brand { get; set; }
        public BranchDetail BranchDetail { get; set; }
        public Address Address { get; set; }

        public Branch()
        { }

        public Branch(string name, string description, bool isDisabled) 
        {
            Name = name;
            Description = description;
            IsDisabled = IsDisabled;
        }

        public Branch(string name, string description, bool isDisabled, Address address) 
        {
            Name = name;
            Description = description;
            IsDisabled = isDisabled;
            Address = address;
        }

        public Branch(string name, string description, bool isDisabled, BranchDetail branchDetail, Address address) 
        {
            Name = name;
            Description = description;
            IsDisabled = isDisabled;
            BranchDetail = branchDetail;
            Address = address;
        }

        public Branch(Guid id, string name, string description, bool isDisabled, BranchDetail branchDetail, Address address) 
        {
            Id = id;
            Name = name;
            Description = description;
            IsDisabled = isDisabled;
            BranchDetail = branchDetail;
            Address = address;
        }

        public void Update(string name, string description, bool isDisabled, Address address) 
        {
            Name = name;
            Description = description;
            IsDisabled = isDisabled;
            Address = address;
        }
    }
}