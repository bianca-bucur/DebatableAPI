using AutoMapper;
using DebatableAPI.Authorization;
using DebatableAPI.DTOs;
using DebatableAPI.Models;
using DebatableAPI.Requests;
using DebatableAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DebatableAPI.Controllers
{
  //[Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly IMapper _mapper;

    private readonly IUserService _userService;

    public UsersController(IMapper mapper, IUserService userService)
    {
      _mapper = mapper;
      _userService = userService;
    }

    [HttpGet]
    public ActionResult<List<User>> Get() =>
      _userService.Get();

    [HttpGet("{username}", Name = "GetUser")]
    public ActionResult<User> Get(string username)
    {
      var user = _userService.Get(username);

      if(user == null)
      {
        return NotFound();
      }
      
      return Ok(user);  
    }

    [HttpPost(Name ="NewUser")]
    public ActionResult<User> Create(NewUserDTO user)
    {
      var _newUser = _mapper.Map<User>(user);
      _userService.Create(_newUser);

      var _responseDTO=_mapper.Map<UserDTO>(_newUser);

      return CreatedAtRoute("GetUser", new { username = user.Username.ToString() }, _responseDTO);
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string username, User userIn)
    {
      var user = _userService.Get(username);

      if (user == null)
      {
        return NotFound();
      }

      _userService.Update(username, userIn);

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string username)
    {
      var user=_userService.Get(username);

      if (user == null)
      {
        return NotFound();
      }

      _userService.Remove(username);

      return NoContent();
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
      if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password)){
        return BadRequest("Missing login details");
      }

      LoginResponse loginResponse = await _userService.Login(loginRequest);

      if(loginResponse == null)
      {
        return BadRequest("Invalid credentials");
      }

      return Ok(loginResponse);
    }
  }
}
