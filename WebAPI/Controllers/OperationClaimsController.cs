using Business.Abstract;
using Core.Entities.Concete;
using Microsoft.AspNetCore.Mvc;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OperationClaimsController : Controller
{
    private IOperationClaimService _operationClaimService;
    
    public OperationClaimsController(IOperationClaimService operationClaimService)
    {
        _operationClaimService = operationClaimService;
    }
    [NonAction]
    public IActionResult Dondur(IResult result)
    {
        if (result.Success) return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("getAll")]
    public IActionResult GetAll()
    {
        var result = _operationClaimService.GetAll();
        return Dondur(result);
    }

    [HttpGet("getById")]
    public IActionResult GetById(int id)
    {
        var result = _operationClaimService.GetById(id);
        return Dondur(result);
    }


    [HttpPost("add")]
    public IActionResult Add(OperationClaim operationClaim)
    {
        var result = _operationClaimService.Add(operationClaim);
        return Dondur(result);
    }

    [HttpPut("update")]
    public IActionResult Put(OperationClaim operationClaim)
    {
        var result = _operationClaimService.Update(operationClaim);
        return Dondur(result);
    }

    [HttpDelete("delete")]
    public IActionResult Delete(int id)
    {
        var result = _operationClaimService.Delete(id);
        return Dondur(result);
    }
}