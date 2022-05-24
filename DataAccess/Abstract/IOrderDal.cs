using System.Collections.Generic;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
        List<OrderCustomerDto> GetOrderCustomer();
        List<OrderEmployeeDto> GetOrderEmployee();
    }
}