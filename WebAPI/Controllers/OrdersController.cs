using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : Controller
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
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
        var result = _orderService.GetAll();
        return Dondur(result);
    }

    [HttpGet("getById")]
    public IActionResult GetById(int id)
    {
        var result = _orderService.GetById(id);
        return Dondur(result);
    }

    [HttpGet("getAllByCustomerId")]
    public IActionResult GetAllByCustomer(string customerId)
    {
        var result = _orderService.GetAllByCustomerId(customerId);
        return Dondur(result);
    }

    [HttpGet("getAllByEmployeeId")]
    public IActionResult GetAllByEmployee(int employeeId)
    {
        var result = _orderService.GetAllByEmployeeId(employeeId);
        return Dondur(result);
    }

    [HttpGet("getAllOrdersCustomers")]
    public IActionResult GetAllOrdersCustomers()
    {
        var result = _orderService.GetOrderCustomer();
        return Dondur(result);
    }

    [HttpGet("getAllOrdersEmployees")]
    public IActionResult GetAllOrdersEmployees()
    {
        var result = _orderService.GetOrderEmployee();
        return Dondur(result);
    }

    [HttpPost("add")]
    public IActionResult Add(Order order)
    {
        var result = _orderService.Add(order);
        return Dondur(result);
    }

    [HttpPut("update")]
    public void Put(Order order)
    {
        _orderService.Update(order);
    }

    [HttpDelete("delete")]
    public IActionResult Add(int orderId)
    {
        var result = _orderService.Delete(orderId);
        return Dondur(result);
    }
}