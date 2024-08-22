
using ItAcademy.MVC.Models;
using ItAcademy.PL.Models;
using ItAcademy.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace ItAcademy.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IRoleService _roleService;

    public UserController(IUserService userService, IRoleService roleService)
    {
        _userService = userService;
        _roleService = roleService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        // Code to retrieve comments from the database or any other source
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Register(UserRegisterModel model, CancellationToken token)
    {
        //single usage, shouldn't be there
        {
            await _roleService.CreateRoleAsync("User", token);
        }
        
        await _userService.RegisterUserAsync(model.Email, model.Password, token);
        //geneate token
        return Ok();
    }
}