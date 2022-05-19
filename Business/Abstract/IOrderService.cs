using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<Order> GetById(int orderId);
        IDataResult<List<Order>> GetAll();
        IDataResult<List<Order>> GetAllByCustomerId(string customerId);
        IDataResult<List<Order>> GetAllByEmployeeId(int employeeId);

        IDataResult<List<OrderCustomerDto>> GetOrderCustomer();
        IDataResult<List<OrderEmployeeDto>> GetOrderEmployee();
        List<IResult> Add(Order order);
        IResult Update(Order order);
        IResult Delete(int orderId);
    }
}