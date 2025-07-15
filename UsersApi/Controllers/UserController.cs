using Microsoft.AspNetCore.Mvc;
using UsersApi.Dto;
using UsersApi.Services.Interfaces;

namespace UsersApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class UserController(IUserService service) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() => Ok(service.GetAll());

    [HttpPost]
    public IActionResult Create([FromBody] UserDto dto)
    {
        var user = dto.ToUser();
        service.Create(user);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id) => Ok(service.GetById(id));

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        service.Delete(id);
        return Ok();
    }
}