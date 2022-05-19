using System.Collections.Generic;
using System.Linq;
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
            var result = BusinessRules.Run(CheckIfEmployeeExistsDataResult(employeeId));
            if (result.Success!=true)
            {
                return (IDataResult<Employee>)result;
            }
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
            var result = BusinessRules.Run(CheckIfCityExists(city));
            if (result.Success!=true)
            {
                return (IDataResult<List<Employee>>)result;
            }
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(employee => employee.City == city));
        }

        [CacheAspect]
        public IDataResult<List<Employee>> GetAllByPostalCode(string postalCode)
        {
            var result = BusinessRules.Run(CheckIfPostalCodeExists(postalCode));
            if (result.Success!=true)
            {
                return (IDataResult<List<Employee>>)result;
            }
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(employee => employee.PostalCode == postalCode));
        }

        [CacheAspect]
        public IDataResult<List<Employee>> GetAllByCountry(string country)
        {
            var result = BusinessRules.Run(CheckIfCountryExists(country));
            if (result.Success!=true)
            {
                return (IDataResult<List<Employee>>)result;
            }
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(employee => employee.Country == country));
        }


        [ValidationAspect(typeof(EmployeeValidator))]
        // [TransactionScopeAspect]
        [CacheRemoveAspect("IEmployeeService.Get")]
        public IResult Add(Employee employee)
        {
            var result = BusinessRules.Run(CheckIfEmployeeExistsForReportsTo(employee.ReportsTo));

            if (result.Success !=true)
            {
                return result;
            }
            employee.EmployeeID = null;
            _employeeDal.Add(employee);
            return new SuccessResult(Messages.EmployeeAdded);
        }

        [ValidationAspect(typeof(EmployeeValidator))]
        [CacheRemoveAspect("IEmployeeService.Get")]
        public IResult Update(Employee employee)
        {
            var result = BusinessRules.Run(CheckIfEmployeeExists(employee.EmployeeID),CheckIfEmployeeExistsForReportsTo(employee.ReportsTo));

            if (result.Success!=true)
            {
                return result;
            }

            _employeeDal.Update(employee);
            return  new SuccessResult(Messages.EmployeeUpdated);
        }

        [CacheRemoveAspect("IEmployeeService.Get")]
        public IResult Delete(int employeeId)
        {
            var entity = _employeeDal.Get(employee => employee.EmployeeID == employeeId);
            _employeeDal.Delete(entity);
            return new SuccessResult(Messages.EmployeeDeleted);
        }

        private IResult CheckIfEmployeeExistsForReportsTo(int employeeId)
        {
            var result = _employeeDal.GetAll(employee => employee.EmployeeID == employeeId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.EmployeeNotExistsForReportsTo);
            }

            return new SuccessResult();
        }
        private IResult CheckIfCityExists(string city)
        {
            var result = _employeeDal.GetAll(employee => employee.City==city).Any();
            if (!result)
            {
                return new ErrorResult(Messages.EmployeeCityNotFound);
            }

            return new SuccessResult();
        }
        private IDataResult<List<Employee>> CheckIfPostalCodeExists(string postalCode)
        {
            var result = _employeeDal.GetAll(employee => employee.PostalCode==postalCode).Any();
            if (!result)
            {
                return new ErrorDataResult<List<Employee>>(Messages.EmployeeCityNotFound);
            }

            return new SuccessDataResult<List<Employee>>();
        }
        private IDataResult<List<Employee>> CheckIfCountryExists(string country)
        {
            var result = _employeeDal.GetAll(employee => employee.Country==country).Any();
            if (!result)
            {
                return new ErrorDataResult<List<Employee>>(Messages.EmployeeCountryNotFound);
            }

            return new SuccessDataResult<List<Employee>>();
        }
        private IDataResult<Employee> CheckIfEmployeeExistsDataResult(int employeeId)
        {
            var result = _employeeDal.GetAll(employee => employee.EmployeeID==employeeId).Any();
            if (!result)
            {
                return new ErrorDataResult<Employee>(Messages.EmployeeNotFound);
            }

            return new SuccessDataResult<Employee>();
        }private IResult CheckIfEmployeeExists(int? employeeId)
        {
            var result = _employeeDal.GetAll(employee => employee.EmployeeID==employeeId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.EmployeeNotFound);
            }

            return new SuccessResult();
        }
    }
}