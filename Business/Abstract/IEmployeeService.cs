using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        IDataResult<Employee> GetById(int employeeId);
        IDataResult<List<Employee>> GetAll();
        IDataResult<List<Employee>> GetAllByCity(string city);
        IDataResult<List<Employee>> GetAllByPostalCode(string postalCode);
        IDataResult<List<Employee>> GetAllByCountry(string country);

        IResult Add(Employee customer);
        IResult Update(Employee customer);
        IResult Delete(int customerId);
    }
}