using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        [CacheAspect]
        public IDataResult<Employee> GetById(int employeeId)
        {
            return new SuccessDataResult<Employee>(_employeeDal.Get(employee => employee.EmployeeID == employeeId));
        }

        [CacheAspect]
        public IDataResult<List<Employee>> GetAll()
        {
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(), Messages.EmployeesListed);
        }

        [CacheAspect]
        public IDataResult<List<Employee>> GetAllByCity(string city)
        {
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(employee => employee.City == city));
        }

        [CacheAspect]
        public IDataResult<List<Employee>> GetAllByPostalCode(string postalCode)
        {
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(employee => employee.PostalCode == postalCode));
        }

        [CacheAspect]
        public IDataResult<List<Employee>> GetAllByCountry(string country)
        {
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(employee => employee.Country == country));
        }


        [ValidationAspect(typeof(EmployeeValidator))]
        // [TransactionScopeAspect]
        [CacheRemoveAspect("IEmployeeService.Get")]
        public IResult Add(Employee employee)
        {
            var result = BusinessRules.Run(CheckIfEmployeeExistsForReportsTo(employee.ReportsTo));

            if (result != null)
            {
                return result;
            }
            employee.EmployeeID = null;
            _employeeDal.Add(employee);
            return new SuccesResult(Messages.EmployeeAdded);
        }

        [ValidationAspect(typeof(EmployeeValidator))]
        [CacheRemoveAspect("IEmployeeService.Get")]
        public IResult Update(Employee employee)
        {
            var result = BusinessRules.Run(CheckIfEmployeeExistsForReportsTo(employee.ReportsTo));

            if (result != null)
            {
                return result;
            }

            _employeeDal.Update(employee);
            return  new SuccesResult(Messages.EmployeeUpdated);
        }

        [CacheRemoveAspect("IEmployeeService.Get")]
        public IResult Delete(int employeeId)
        {
            var entity = _employeeDal.Get(employee => employee.EmployeeID == employeeId);
            _employeeDal.Delete(entity);
            return new SuccesResult(Messages.EmployeeDeleted);
        }

        private IResult CheckIfEmployeeExistsForReportsTo(int employeeId)
        {
            var result = _employeeDal.GetAll(employee => employee.EmployeeID == employeeId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.EmployeeNotExistsForReportsTo);
            }

            return new SuccesResult();
        }
    }
}