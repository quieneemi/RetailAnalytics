using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetAnal.Core.Interfaces;
using RetAnal.Core.Models;

namespace RetAnal.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
[Authorize(Roles = "Administrator")]
public class OffersController : Controller
{
    private readonly IOffersService _offers;

    public OffersController(IOffersService offersService) => _offers = offersService;

    [HttpPost("{offerName}")]
    public async Task<ActionResult<Table>> Execute(string offerName, [FromBody] string[] parameters)
    {
        var result = await _offers.GetAsync(offerName, parameters);
        return Ok(result);
    }
}