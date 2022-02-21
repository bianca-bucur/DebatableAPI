using DebatableAPI.Models;
using DebatableAPI.Services;
using Microsoft.Extensions.Options;
using AutoMapper;
using DebatableAPI.DTOs;

namespace DebatableAPI.Profiles
{
  public class UsersProfiles : Profile
  {
    public UsersProfiles()
    {
      CreateMap<UserDTO, User>();
      CreateMap<User, UserDTO>();
      CreateMap<NewUserDTO, User>();
    }
  }
}
