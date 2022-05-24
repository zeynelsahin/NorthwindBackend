using Entities.Concrete;

namespace Entities.DTOs
{
    public class OrderCustomerDto
    {
        public Order Order { get; set; }
        public Customer Customer { get; set; }
    }
}