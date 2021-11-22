using DebatableAPI.Models;
using DebatableAPI.Requests;
using MongoDB.Driver;

namespace DebatableAPI.Services
{
  public interface IUserService
  {
    Task<LoginResponse> Login(LoginRequest loginRequest);
    List<User> Get();
    User Get(string username);
    User Create(User user);
    void Update(string username, User user);
    void Remove(string username);
    void Remove(User userIn);
  }
}
