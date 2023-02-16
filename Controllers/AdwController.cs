using Microsoft.AspNetCore.Mvc;
using az_sql_ad_auth.DAL;
using az_sql_ad_auth.Models;
using Microsoft.EntityFrameworkCore;

namespace az_sql_ad_auth.Controllers;

[ApiController]
[Route("[controller]")]
public class AdwController : ControllerBase
{
    private readonly ILogger<AdwController> _logger;
    private readonly AdwContext _ctx;

    public AdwController(ILogger<AdwController> logger, AdwContext ctx)
    {
        _logger = logger;
        _ctx = ctx;
    }

    [HttpGet(Name = "GetCustomers")]
    public async Task<IActionResult> Get()
    {
        var customers = await _ctx.Customers.ToListAsync();
	    return Ok(customers);    
    }
}
