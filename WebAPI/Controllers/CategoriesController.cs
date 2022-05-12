using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using IResult = Core.Utilities.Results.IResult;
namespace WebAPI.Controllers;

public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    { 
        _categoryService=categoryService;
    }
    public IActionResult Dondur(IResult result)
    {
        if (result.Success) return Ok(result);
        return BadRequest(result);
    }
    
    [HttpGet("getall")]
    public IActionResult Index()
    {
        var result = _categoryService.GetAll();
        return Dondur(result);
    }
}