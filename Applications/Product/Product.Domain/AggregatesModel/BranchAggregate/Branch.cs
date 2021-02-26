using System;
using System.Collections.Generic;
using Product.Domain.SeedWork;

namespace Product.Domain.AggregatesModel.BranchAggregate
{
    public class Branch:Entity, IAggregateRoot
    {
        public Guid BranchId { get; set; }       
        public string Name { get; set; }
        public bool IsDisabled { get; set; }
        public ICollection<Product.Domain.AggregatesModel.ProductAggregate.Product> Products { get; set; }

        public Branch()
        { }

        public Branch(Guid branchId, string name, bool IsDisabled) 
        {
            this.BranchId = branchId;
            this.Name = name;
            this.IsDisabled = IsDisabled;
        }

        public Branch(Guid id, Guid branchId, string name, bool IsDisabled) 
        {
            this.Id = id;
            this.BranchId = branchId;
            this.Name = name;
            this.IsDisabled = IsDisabled;
        }

    }
}