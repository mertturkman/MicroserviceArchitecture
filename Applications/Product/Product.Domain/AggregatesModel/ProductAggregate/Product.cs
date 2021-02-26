using System;
using Product.Domain.AggregatesModel.BranchAggregate;
using Product.Domain.SeedWork;

namespace Product.Domain.AggregatesModel.ProductAggregate
{
    public class Product:Entity, IAggregateRoot 
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public bool IsDisabled { get; protected set; }
        public Branch Branch { get; protected set; }
        public ProductDetail ProductDetail { get; protected set; }

        public Product ()
        { }

        public Product(string name, string description, bool isDisabled) 
        {
            Name = name;
            Description = description;
            IsDisabled = isDisabled;
        }
        
        public Product(string name, string description,  bool isDisabled, ProductDetail productDetail, Branch branch) 
        {
            Name = name;
            Description = description;
            IsDisabled = isDisabled;
            ProductDetail = productDetail;
            Branch = branch;
        }

        public Product(Guid id, string name, string description,  bool isDisabled, ProductDetail productDetail, Branch branch) 
        {
            Id = id;
            Name = name;
            Description = description;
            IsDisabled = isDisabled;
            ProductDetail = productDetail;
            Branch = branch;
        }

        public void Update(string name, string description,  bool isDisabled, string jsonData) 
        {
            Name = name;
            Description = description;
            IsDisabled = isDisabled;
            ProductDetail.JsonData = jsonData;
        }
    }
}