using System;
using System.Threading.Tasks;
using CatADog.Domain.Model.Validation;
using CatADog.Domain.Model.ViewModels;
using CatADog.Domain.Services;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> Get(long id)
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
    public async Task<IActionResult> InsertViewModel(AdopterFormViewModel viewModel)
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
    public async Task<IActionResult> UpdateViewModel([FromBody] AdopterFormViewModel viewModel, long id)
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

            await DeleteAsync(id);

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
}