using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : Controller
{
    private ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [NonAction]
    public IActionResult Dondur(IResult result)
    {
        if (result.Success) return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _customerService.GetAll();
        return Dondur(result);
    }

    [HttpGet("getByCity")]
    public IActionResult GetById(string city)
    {
        var result = _customerService.GetAllByCity(city);
        return Dondur(result);
    }

    [HttpGet("getAllByPostalCode")]
    public IActionResult GetAllByCategory(string postalCode)
    {
        var result = _customerService.GetAllByPostalCode(postalCode);
        return Dondur(result);
    }

    [HttpGet("getAllByCountry")]
    public IActionResult GetByUnitPrice(string country)
    {
        var result = _customerService.GetAllByCountry(country);
        return Dondur(result);
    }


    [HttpPost("add")]
    public IActionResult Add(Customer customer)
    {
        var result = _customerService.Add(customer);
        return Dondur(result);
    }

    [HttpPut("update")]
    public IActionResult Put(Customer customer)
    {
        var result = _customerService.Update(customer);
        return Dondur(result);
    }

    [HttpDelete("delete")]
    public IActionResult Delete(string id)
    {
        var result = _customerService.Delete(id);
        return Dondur(result);
    }
}