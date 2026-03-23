using Microsoft.AspNetCore.Mvc;
using RealEstateSystem.Application.Abstractions.Services;
using RealEstateSystem.Application.DTOs.Person;
using RealEstateSystem.Application.Services;

namespace RealEstateSystem.Controllers.PersonController;

[ApiController]
[Route("persons")]
public class PersonController(IPersonService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await service.GetAll();

        return Ok(result);
    }

    [HttpGet("{personId}")]
    public async Task<IActionResult> GetById([FromRoute] Guid personId)
    {
        var result = await service.GetById(personId);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePersonDto request)
    {
        var result = await service.Create(request);

        return CreatedAtAction(nameof(Create), new { personId = result.Id }, result);
    }

    [HttpPut("{personId}")]
    public async Task<IActionResult> Update([FromRoute] Guid personId,
                                            [FromBody] UpdatePersonDto request)
    {
        var result = await service.Update(personId, request);

        return Ok(result);
    }

    [HttpDelete("{personId}")]
    public async Task<IActionResult> Delete([FromRoute] Guid personId)
    {
        await service.Remove(personId);

        return NoContent();
    }
}
