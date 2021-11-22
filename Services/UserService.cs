

using DebatableAPI.Helpers;
using DebatableAPI.Models;
using DebatableAPI.Requests;
using MongoDB.Driver;

namespace DebatableAPI.Services
{
  public class UserService : IUserService
  {
    private readonly IMongoCollection<User> _users;
    
    public UserService(IDebatableDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _users=database.GetCollection<User>(settings.UsersCollectionName);  
    }

    public List<User> Get()=> 
      _users.Find(user => true).ToList();

    public User Get(string username) =>
      _users.Find(user => user.Username == username).FirstOrDefault();

    public User Create(User user)
    {
      string pass = HashingHelper.HashUsingPbkdf2(user.Password, "h3QBI/v5XCkFFJEnjRt8wQ==");

      user.Password = pass;

      _users.InsertOne(user); 
      return user;
    }

    public void Update(string username, User userIn) =>
      _users.ReplaceOne(user => user.Username == username, userIn);

    public void Remove(string username) =>
      _users.DeleteOne(user => user.Username == username);

    public void Remove(User userIn) =>
      _users.DeleteOne(user => user.Username == userIn.Username);

    public async Task<LoginResponse> Login(LoginRequest loginRequest)
    {
      User user=_users.Find(user=>user.Username == loginRequest.Username).FirstOrDefault();

      if(user == null)
      {
        return null;
      }

      string passwordHash = HashingHelper.HashUsingPbkdf2(loginRequest.Password, "h3QBI/v5XCkFFJEnjRt8wQ==");

      if(user.Password != passwordHash)
      {
        return null;
      }

      string token = await Task.Run(() => TokenHelper.GenerateToken(user));

      return new LoginResponse
      {
        Username = user.Username,
        Token = token
      };
    }
  }
}
