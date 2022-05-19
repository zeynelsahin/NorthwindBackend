using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : Controller
{
    private IEmployeeService _employeesService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeesService = employeeService;
    }

    [NonAction]
    private IActionResult Dondur(IResult result)
    {
        if (result.Success) return Ok(result);
        return BadRequest(result);
    }

    [NonAction]
    private IActionResult Dondur(List<IResult> result)
    {
        if (result[0].Success) return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("getAll")]
    public IActionResult GetAll()
    {
        var result = _employeesService.GetAll();
        return Dondur(result);
    }

    [HttpGet("getById")]
    public IActionResult GetById(int employeeId)
    {
        var result = _employeesService.GetById(employeeId);
        return Dondur(result);
    }


    [HttpGet("getByCity")]
    public IActionResult GetById(string city)
    {
        var result = _employeesService.GetAllByCity(city);
        return Dondur(result);
    }

    [HttpGet("getAllByPostalCode")]
    public IActionResult GetAllByCategory(string postalCode)
    {
        var result = _employeesService.GetAllByPostalCode(postalCode);
        return Dondur(result);
    }

    [HttpGet("getAllByCountry")]
    public IActionResult GetByUnitPrice(string country)
    {
        var result = _employeesService.GetAllByCountry(country);
        return Dondur(result);
    }


    [HttpPost("add")]
    public IActionResult Add(Employee employee)
    {
        var result = _employeesService.Add(employee);
        return Dondur(result);
    }

    [HttpPut("update")]
    public IActionResult Put(Employee employee)
    {
        var result = _employeesService.Update(employee);
        return Dondur(result);
    }

    [HttpDelete("delete")]
    public IActionResult Delete(int id)
    {
        var result = _employeesService.Delete(id);
        return Dondur(result);
    }
}