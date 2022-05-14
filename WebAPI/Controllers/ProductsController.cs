using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
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
        var result = _productService.GetAll();
        return Dondur(result);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        var result = _productService.GetById(id);
        return Dondur(result);
    }

    [HttpPost("add")]
    public IActionResult Add(Product product)
    {
        var result = _productService.Add(product);
        return Dondur(result);
    }

    [HttpGet("getallbycategory")]
    public IActionResult GetAllByCategory(int id)
    {
        var result = _productService.GetAllByCategory(id);
        return Dondur(result);
    }

    [HttpGet("getbyunitprice")]
    public IActionResult GetByUnitPrice(decimal min, decimal max)
    {
        var result = _productService.GetByUnitPrice(min, max);
        return Dondur(result);
    }


    [HttpGet("getproductsdetails")]
    public IActionResult GetProductsDetails()
    {
        var result = _productService.GetProductDetails();
        return Dondur(result);
    }

    [HttpPut("update")]
    public void Put(Product product)
    {
        var result = _productService.UpdateProduct(product);
    }
}