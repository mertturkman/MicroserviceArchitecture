using System;
using System.Collections.Generic;
using Branch.Domain.SeedWork;

namespace Branch.Domain.AggregatesModel.BranchAggregate
{
    public class BranchDetail:Entity 
    {
        public string JsonData { get; set; }
        Branch Branch { get; set; }

        public BranchDetail ()
        { }

        public BranchDetail(string jsonData) 
        {
            JsonData = jsonData;
        }

        public BranchDetail(Guid id, string jsonData, Branch branch) 
        {
            Id = id;
            JsonData = jsonData;
            Branch = branch;
        }

        public void Update(string jsonData) 
        {
            JsonData = jsonData;
        }
    }
}