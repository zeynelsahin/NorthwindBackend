using System;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Entities.DTOs
{
    public class OrderCustomerDto
    {
        public Order Order { get; set; }
        public Customer Customer { get; set; }
    
    }
}