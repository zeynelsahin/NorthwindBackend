using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, NorthwindContext>, IOrderDal
    {
        public List<OrderCustomerDto> GetOrderCustomer()
        {
            using (var context = new NorthwindContext())
            {
                var result = from order in context.Orders
                    join customer in context.Customers on order.CustomerId equals customer.CustomerID
                    select new OrderCustomerDto()
                    {
                        Order = order,
                        Customer = customer
                    };
                return result.ToList();
            }
        }

        public List<OrderEmployeeDto> GetOrderEmployee()
        {
            using (var context = new NorthwindContext())
            {
                var result = from order in context.Orders
                    join employee in context.Employees on order.EmployeeId equals employee.EmployeeID
                    select new OrderEmployeeDto()
                    {
                        Order = order,
                        Employee = employee
                    };
                return result.ToList();
            }
        }
    }
}