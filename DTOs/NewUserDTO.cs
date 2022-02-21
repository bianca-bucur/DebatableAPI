using DebatableAPI.Models;

namespace DebatableAPI.DTOs
{
  public class NewUserDTO
  {
    public string Username { get; set; } 
    public string Password { get; set; }  
    public string Nickname { get; set; }  
    public string Email { get; set; }
  }
}
