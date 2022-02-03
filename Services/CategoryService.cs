using DebatableAPI.Models;
using MongoDB.Driver;

namespace DebatableAPI.Services
{
  public class CategoryService : ICategoryService
  {
    private readonly IMongoCollection<Category> _categories;

    public CategoryService(IDebatableDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _categories = database.GetCollection<Category>(settings.CategoriesCollectionName);

      var options = new CreateIndexOptions { Unique = true };
      _categories.Indexes.CreateOne("{name: 1}", options);
    }

    public List<Category> Get() =>
      _categories.Find(category => true).ToList();

    public Category Get(string name) =>
      _categories.Find(category => category.Name == name).FirstOrDefault();

    public Category Create(Category category)
    {
      _categories.InsertOne(category);

      return category;      
    }

    public void Remove(string name) =>
      _categories.DeleteOne(category => category.Name == name);

    public void Update(string name, Category categoryIn) =>
      _categories.ReplaceOne(category => category.Name == name, categoryIn);
  }
}
