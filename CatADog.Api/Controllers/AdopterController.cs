using System;
using System.Data.SQLite;
using System.Threading.Tasks;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Model.Validation;
using CatADog.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Exceptions;

namespace CatADog.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdopterController : ControllerBase
{
    private readonly AdopterService _service;

    public AdopterController(AdopterService service)
    {
        _service = service;
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        try
        {
            var entity = await _service.GetAsync(id);

            if (entity == null)
                return NotFound();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [HttpGet("DropDownList")]
    public async Task<IActionResult> GetDropDownListAsync()
    {
        try
        {
            var result = await _service.GetDropDownList();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(Adopter entity)
    {
        try
        {
            entity = await _service.InsertAsync(entity);

            return CreatedAtAction(
                "Get",
                new { id = entity.Id },
                entity);
        }
        catch (ValidatorException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> PutAsync([FromBody] Adopter entity, long id)
    {
        try
        {
            var fromDatabase = await _service.GetAsync(id);
            if (fromDatabase == null)
                return NotFound();

            entity.Id = fromDatabase.Id;
            entity = await _service.UpdateAsync(entity);

            return Ok(entity);
        }
        catch (ValidatorException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        try
        {
            var entity = await _service.GetAsync(id);
            if (entity == null)
                return NotFound();

            await _service.DeleteAsync(entity);

            return NoContent();
        }
        catch (GenericADOException ex)
        {
            return ex.InnerException?.GetType() == typeof(SQLiteException)
                ? BadRequest(ex.InnerException.Message)
                : StatusCode(500, ex);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
}