using System;
using System.Data;
using System.Data.SQLite;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CatADog.Domain.Model.Dtos;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Model.Settings;
using CatADog.Domain.Model.Validation;
using CatADog.Domain.Model.ViewModels;
using CatADog.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NHibernate.Exceptions;

namespace CatADog.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly AppSettings _appSettings;
    private readonly UserService _service;

    public UserController(AppSettings appSettings, UserService service)
    {
        _appSettings = appSettings;
        _service = service;
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetAsync(long id)
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

    [HttpPost]
    public async Task<IActionResult> PostAsync(UserFormViewModel viewModel)
    {
        try
        {
            viewModel = await _service.InsertViewModelAsync(viewModel);

            return CreatedAtAction(
                "Get",
                new { id = viewModel.Id },
                viewModel);
        }
        catch (ConstraintException ex)
        {
            return Conflict(ex.Message);
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

    [HttpPost("Authenticate")]
    [AllowAnonymous]
    public IActionResult Authenticate(UserAuthenticationDto dto)
    {
        try
        {
            var user = _service.FindByEmailAndPassword(dto.Email, dto.Password);
            if (user == null)
                return Ok(new { Token = string.Empty });

            var token = GenerateJwtToken(user);

            return Ok(new { Token = token });
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [HttpPost("ChangePassword")]
    public async Task<IActionResult> ChangePassword(ChangePasswordDto dto)
    {
        try
        {
            return await _service.UpdatePassword(dto)
                ? Ok()
                : NotFound();
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
    public async Task<IActionResult> PutAsync([FromBody] UserFormViewModel viewModel, long id)
    {
        try
        {
            var fromDatabase = await _service.GetAsync(id);
            if (fromDatabase == null)
                return NotFound();

            viewModel.Id = fromDatabase.Id;
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

    private string GenerateJwtToken(User user)
    {
        var key = Encoding.Unicode.GetBytes(_appSettings.Key);
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                // User claims
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
            }),
            Expires = DateTime.UtcNow.AddDays(1), // Expiration time
            Issuer = _appSettings.Issuer,
            Audience = _appSettings.Audience,
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}