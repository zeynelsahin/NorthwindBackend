using Entities.Concrete;

namespace Entities.DTOs
{
    public class OrderEmployeeDto
    {
        public Order Order { get; set; }
        public Employee Employee { get; set; }
    }
}