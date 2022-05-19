using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<Customer> GetById(string customerId);
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<Customer>> GetAllByCity(string city);
        IDataResult<List<Customer>> GetAllByPostalCode(string postalCode);
        IDataResult<List<Customer>> GetAllByCountry(string country);

        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(string customerId);
    }
}