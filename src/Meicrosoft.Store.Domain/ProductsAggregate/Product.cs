using Meicrosoft.Store.Domain.Entities;
using Meicrosoft.Store.Domain.ProductsAggregate.Enums;

namespace Meicrosoft.Store.Domain.ProductsAggregate
{
    public class Product(string name, string description, ECategory category, decimal price) : Entity
    {
        public string Name { get; private set; } = name;
        public string Description { get; private set; } = description;
        public ECategory Category { get; private set; } = category;
        public decimal Price { get; private set; } = price;

        public void CalculatePrice()
        {
            Price += Category == ECategory.Kids ? 50 : 100;
        }
    }
}
