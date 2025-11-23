using Microsoft.AspNetCore.Mvc;
using TenantProject.Model.DTO;
using TenantProject.Services;

namespace TenantProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TenantController : ControllerBase
{
    private readonly TenantService _tenantService;
    public TenantController(TenantService tenantService)
    {
        _tenantService = tenantService;
    }

    [HttpPost]
    public async Task<IActionResult> AddTenant([FromBody] TenantRequestDto requestDto)
    {
        try
        {
            var result = await _tenantService.AddTenant(requestDto);    
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new 
            {
                message = ex.Message
            });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetTenants([FromQuery] string? search)
    {
        try
        {
            var result = await _tenantService.GetTenants(search);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                message = ex.Message
            });
        }
    }


    [HttpGet("Types")]
    public async Task<IActionResult> GetTenantTypes()
    {
        try
        {
            var result = await _tenantService.GetTenantTypes();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                message = ex.Message
            });
        }
    }
}
