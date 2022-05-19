using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        private readonly ICustomerService _customerService;
        private readonly IEmployeeService _employeeService;

        public OrderManager(IOrderDal orderDal, ICustomerService customerService, IEmployeeService employeeService)
        {
            _orderDal = orderDal;
            _customerService = customerService;
            _employeeService = employeeService;
        }

        public IDataResult<Order> GetById(int orderId)
        {
            var result = BusinessRules.Run(CheckIfOrderExistsDataResult(orderId));
            if (result.Success != true)
            {
                return (IDataResult<Order>)result;
            }

            return new SuccessDataResult<Order>(_orderDal.Get(order => order.OrderId == orderId), Messages.OrderListed);
        }

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(), Messages.OrdersListed);
        }

        public IDataResult<List<Order>> GetAllByCustomerId(string customerId)
        {
            var result = BusinessRules.Run(CheckIfCustomerExistsDataResult(customerId), CheckIfCustomerExistsForOrderDataResult(customerId));
            if (result.Success != true)
            {
                return (IDataResult<List<Order>>)result;
            }

            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(order => order.CustomerId == customerId));
        }

        public IDataResult<List<Order>> GetAllByEmployeeId(int employeeId)
        {
            var result = BusinessRules.Run(CheckIfEmployeeExists(employeeId), CheckIfEmployeeExistsForOrder(employeeId));
            if (result.Success != true)
            {
                return (IDataResult<List<Order>>)result;
            }

            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(order => order.EmployeeId == employeeId));
        }
        public IDataResult<List<OrderCustomerDto>> GetOrderCustomer()
        {
            return new SuccessDataResult<List<OrderCustomerDto>>(_orderDal.GetOrderCustomer());
        }
        public IDataResult<List<OrderEmployeeDto>> GetOrderEmployee()
        {
            return new SuccessDataResult<List<OrderEmployeeDto>>(_orderDal.GetOrderEmployee());
        }

        public List<IResult> Add(Order order)
        {
            var result = BusinessRules.RunMultiple(CheckIfCustomerExists(order.CustomerId), CheckIfEmployeeExists(order.EmployeeId));
            if (result.Count > 0)
            {
                return result;
            }

            _orderDal.Add(order);
            return new List<IResult>() { new SuccessResult(Messages.OrderAdded) };
        }

        public IResult Update(Order order)
        {
            var result = BusinessRules.Run(CheckIfCustomerExists(order.CustomerId), CheckIfEmployeeExists(order.EmployeeId));
            if (result.Success != true)
            {
                return result;
            }

            _orderDal.Update(order);
            return new SuccessResult(Messages.OrderUpdated);
        }

        public IResult Delete(int orderId)
        {
            var result = BusinessRules.Run(CheckIfOrderExists(orderId));
            if (result.Success != true)
            {
                return result;
            }

            var entity = _orderDal.Get(order => order.OrderId == orderId);
            _orderDal.Delete(entity);
            return new SuccessResult(Messages.OrderDeleted);
        }

        private IDataResult<Order> CheckIfOrderExistsDataResult(int orderId)
        {
            var result = _orderDal.GetAll(order => order.OrderId == orderId).Any();
            if (!result)
            {
                return new ErrorDataResult<Order>(Messages.OrderNotFound);
            }

            return new SuccessDataResult<Order>();
        }

        private IResult CheckIfOrderExists(int orderId)
        {
            var result = _orderDal.GetAll(order => order.OrderId == orderId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.OrderNotFound);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCustomerExists(string customerId)
        {
            var result = _customerService.GetById(customerId);
            if (result.Data == null)
            {
                return new ErrorResult(Messages.CustomerNotFound);
            }

            return new SuccessResult();
        }private IDataResult<List<Order>> CheckIfCustomerExistsDataResult(string customerId)
        {
            var result = _customerService.GetById(customerId);
            if (result.Data == null)
            {
                return new ErrorDataResult<List<Order>>(Messages.CustomerNotFound);
            }

            return new SuccessDataResult<List<Order>>();
        }

        private IDataResult<List<Order>> CheckIfCustomerExistsForOrderDataResult(string customerId)
        {
            var result = _orderDal.GetAll(order => order.CustomerId == customerId).Any();
            if (!result)
            {
                return new ErrorDataResult<List<Order>>(Messages.OrderNotCustomer);
            }

            return new SuccessDataResult<List<Order>>();
        }

        private IResult CheckIfEmployeeExists(int employeeId)
        {
            var result = _employeeService.GetById(employeeId);
            if (result.Data == null)
            {
                return new ErrorResult(Messages.EmployeeNotFound);
            }

            return new SuccessResult();
        }

        private IResult CheckIfEmployeeExistsForOrder(int employeeId)
        {
            var result = _orderDal.GetAll(order => order.EmployeeId == employeeId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.OrderNotEmployee);
            }

            return new SuccessResult();
        }
    }
}