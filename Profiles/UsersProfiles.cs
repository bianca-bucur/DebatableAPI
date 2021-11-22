using DebatableAPI.Models;
using DebatableAPI.Services;
using Microsoft.Extensions.Options;
using AutoMapper;

namespace DebatableAPI.Profiles
{
  public class UsersProfiles : Profile
  {
    public UsersProfiles()
    {
      CreateMap<UserDTO, User>();
      CreateMap<User, UserDTO>();
    }
  }
}
