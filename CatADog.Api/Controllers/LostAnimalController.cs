using System;
using System.Data.SQLite;
using System.Threading.Tasks;
using CatADog.Domain.Model.Validation;
using CatADog.Domain.Model.ViewModels;
using CatADog.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Exceptions;

namespace CatADog.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LostAnimalController : ControllerBase
{
    private readonly LostAnimalService _service;

    public LostAnimalController(LostAnimalService service)
    {
        _service = service;
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> Get(long id)
    {
        try
        {
            var viewModel = await _service.GetAsViewModelAsync(id);

            if (viewModel == null)
                return NotFound();

            return Ok(viewModel);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [HttpGet("Approved")]
    public IActionResult GetApproved()
    {
        try
        {
            var result = _service.GetApprovedLostAnimal();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [HttpGet("Pending")]
    public IActionResult GetPending()
    {
        try
        {
            var result = _service.GetPendingLostAnimals();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [HttpPost]
    public async Task<IActionResult> InsertViewModel(LostAnimalFormViewModel viewModel)
    {
        try
        {
            viewModel = await _service.InsertViewModelAsync(viewModel);

            return CreatedAtAction(
                "Get",
                new { id = viewModel.Id },
                viewModel);
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
    public async Task<IActionResult> UpdateViewModel([FromBody] LostAnimalFormViewModel viewModel, long id)
    {
        try
        {
            var entity = await _service.GetAsync(id);
            if (entity == null)
                return NotFound();

            viewModel.Id = entity.Id;
            viewModel = await _service.UpdateViewModelAsync(viewModel);

            return Ok(viewModel);
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