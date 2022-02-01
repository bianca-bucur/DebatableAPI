namespace DebatableAPI.Models
{
  public class DebatableDatabaseSettings : IDebatableDatabaseSettings
  {
    public string UsersCollectionName { get; set; }
    public string CategoriesCollectionName { get; set; }
    public string TopicsCollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
  }

  public interface IDebatableDatabaseSettings
  {
    string UsersCollectionName { get;set;}
    string CategoriesCollectionName { get; set; } 
    string TopicsCollectionName { get; set; } 
    string ConnectionString { get; set;} 
    string DatabaseName { get; set;} 
  }
}
