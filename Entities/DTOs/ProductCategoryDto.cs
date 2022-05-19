using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class ProductCategoryDto : IDto
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }

        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}