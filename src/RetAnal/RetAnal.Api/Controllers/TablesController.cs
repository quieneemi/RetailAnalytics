using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetAnal.Core.Models;
using RetAnal.Core.Interfaces;

namespace RetAnal.Api.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]/{tableName}")]
public class TablesController : Controller
{
    private const string PathToData = "/var/lib/postgresql/data";
    private readonly ITablesService _tables;

    public TablesController(ITablesService tablesService) => _tables = tablesService;

    [HttpGet]
    public async Task<ActionResult<Table>> GetTable(string tableName, int pageIndex = 0, int pageSize = 0)
    {
        var table = await _tables.GetTableAsync(tableName, pageIndex, pageSize);
        return Ok(table);
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Insert(string tableName, [FromBody] string[] values)
    {
        await _tables.InsertAsync(tableName, values);
        return NoContent();
    }

    [HttpPut]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Update(string tableName, [FromBody] string[] values)
    {
        await _tables.UpdateAsync(tableName, values);
        return NoContent();
    }

    [HttpDelete]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Delete(string tableName, [FromBody] string[] values)
    {
        await _tables.DeleteAsync(tableName, values);
        return NoContent();
    }

    [HttpPost("Import")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Import(string tableName, IFormFile? file)
    {
        if (file is not { Length: > 0 }) return BadRequest();

        var fileName = Path.GetRandomFileName();
        var filePath = Path.Combine(PathToData, fileName);
        await using (var stream = System.IO.File.Create(filePath))
        {
            await file.CopyToAsync(stream);
        }

        await _tables.ImportAsync(tableName, fileName);

        return NoContent();
    }
}