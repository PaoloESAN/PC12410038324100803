using Microsoft.AspNetCore.Mvc;
using PC12410038324100803.CORE.core.DTOs;
using PC12410038324100803.CORE.core.Interfaces;

namespace PC12410038324100803.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdenservicioController : ControllerBase
{
    private readonly IOrdenServicioService _service;

    public OrdenservicioController(IOrdenServicioService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var list = await _service.GetAll();
        return Ok(list);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var dto = await _service.GetById(id);
        if (dto == null) return NotFound();
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OrdenservicioCreateDTO dto)
    {
        await _service.Create(dto);
        return Ok(dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] OrdenservicioUpdateDTO dto)
    {
        if (id != dto.Id) return BadRequest();
        await _service.Update(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }
}
