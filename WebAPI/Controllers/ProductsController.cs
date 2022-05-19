using Business.Abstract;
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

    [NonAction]
    public IActionResult Dondur(List<IResult> result)
    {
        if (result[0].Success) return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("getAll")]
    public IActionResult GetAll()
    {
        var result = _productService.GetAll();
        return Dondur(result);
    }

    [HttpGet("getById")]
    public IActionResult GetById(int id)
    {
        var result = _productService.GetById(id);
        return Dondur(result);
    }


    [HttpGet("getAllByCategory")]
    public IActionResult GetAllByCategory(int id)
    {
        var result = _productService.GetAllByCategory(id);
        return Dondur(result);
    }

    [HttpGet("getByUnitprice")]
    public IActionResult GetByUnitPrice(decimal min, decimal max)
    {
        var result = _productService.GetByUnitPrice(min, max);
        return Dondur(result);
    }


    [HttpGet("getProductsCategories")]
    public IActionResult GetProductsDetails()
    {
        var result = _productService.GetProductCategory();
        return Dondur(result);
    }

    [HttpGet("getProductsSuppliers")]
    public IActionResult GetProductsSuppliers()
    {
        var result = _productService.GetProductSupplier();
        return Dondur(result);
    }

    [HttpPost("add")]
    public IActionResult Add(Product product)
    {
        var result = _productService.Add(product);
        return Dondur(result);
    }

    [HttpPut("update")]
    public void Put(Product product)
    {
        _productService.Update(product);
    }

    [HttpPost("delete")]
    public IActionResult Add(int productId)
    {
        var result = _productService.Delete(productId);
        return Dondur(result);
    }
}