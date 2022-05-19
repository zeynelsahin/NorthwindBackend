using System.Collections.Generic;
using System.ComponentModel;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [CacheAspect]
        public IDataResult<Customer> GetById(string customerId)
        {
            var result = BusinessRules.Run(CheckIfCustomerExists(customerId));
            if (result.Success != true) return (IDataResult<Customer>)result;
            return new SuccessDataResult<Customer>(_customerDal.Get(customer => customer.CustomerID == customerId), Messages.CustomerListed);
        }

        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomersListed);
        }

        [CacheAspect]
        public IDataResult<List<Customer>> GetAllByCity(string city)
        {
            var result = BusinessRules.Run(CheckIfCategoryCityExists(city));
            if (result.Success != true) return (IDataResult<List<Customer>>)result;


            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(customer => customer.City == city), Messages.CustomersListed);
        }

        [CacheAspect]
        public IDataResult<List<Customer>> GetAllByPostalCode(string postalCode)
        {
            var result = BusinessRules.Run(CheckIfPostalCodeExists(postalCode));
            if (result.Success != true) return (IDataResult<List<Customer>>)result;

            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(customer => customer.PostalCode == postalCode), Messages.CustomersListed);
        }

        [CacheAspect]
        public IDataResult<List<Customer>> GetAllByCountry(string country)
        {
            var result = BusinessRules.Run(CheckIfCountryExists(country));
            if (result.Success != true) return (IDataResult<List<Customer>>)result;
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(customer => customer.Country == country), Messages.CustomersListed);
        }


        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }

        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Delete(string customerId)
        {
            var entity = _customerDal.Get(customer => customer.CustomerID == customerId);
            _customerDal.Delete(entity);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        private IDataResult<Customer> CheckIfCustomerExists(string customerId)
        {
            var result = _customerDal.GetAll(customer => customer.CustomerID == customerId).Any();
            if (!result) return new ErrorDataResult<Customer>(Messages.CustomerNotFound);

            return new SuccessDataResult<Customer>();
        }

        private IDataResult<List<Customer>> CheckIfCategoryCityExists(string city)
        {
            var result = _customerDal.GetAll(p => p.City == city).Any();
            if (!result) return new ErrorDataResult<List<Customer>>(Messages.CustomerCityNotFound);

            return new SuccessDataResult<List<Customer>>();
        }

        private IDataResult<List<Customer>> CheckIfPostalCodeExists(string postalCode)
        {
            var result = _customerDal.GetAll(customer => customer.PostalCode == postalCode).Any();
            if (!result) return new ErrorDataResult<List<Customer>>(Messages.CustomerPostalCodeNotFound);

            return new SuccessDataResult<List<Customer>>();
        }

        private IDataResult<List<Customer>> CheckIfCountryExists(string country)
        {
            var result = _customerDal.GetAll(customer => customer.Country == country).Any();
            if (!result) return new ErrorDataResult<List<Customer>>(Messages.CustomerPostalCodeNotFound);

            return new SuccessDataResult<List<Customer>>();
        }
    }
}