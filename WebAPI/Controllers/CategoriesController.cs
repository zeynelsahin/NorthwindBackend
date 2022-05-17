using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [NonAction]
    public IActionResult Dondur(IResult result)
    {
        if (result.Success) return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("getAll")]
    public IActionResult Index()
    {
        var result = _categoryService.GetAll();
        return Dondur(result);
    }

    [HttpGet("getByİd")]
    public IActionResult Index(int id)
    {
        var result = _categoryService.GetById(id);
        return Dondur(result);
    }

    [HttpPost("add")]
    public IActionResult Add(Category category)
    {
        var result = _categoryService.Add(category);
        return Dondur(result);
    }

    [HttpPut("update")]
    public IActionResult Put(Category category)
    {
        var result = _categoryService.Update(category);
        return Dondur(result);
    }

    [HttpDelete("delete")]
    public IActionResult Delete(int id)
    {
        var result = _categoryService.Delete(id);
        return Dondur(result);
    }
}