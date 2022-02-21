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

    #region Category

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

    #endregion

    #region Topics

    public List<Topic> GetTopics(string categoryName) => _categories.Find(category => category.Name == categoryName).FirstOrDefault().Topics.ToList();

    public Topic Get(string categoryName, string topicTitle)
    {
      return _categories.Find(category => category.Name == categoryName).FirstOrDefault().Topics.ToList().Find(topic => topic.Title == topicTitle);
    }

    public Topic Create(string categoryName, Topic topic)
    {
      _categories.Find(category => category.Name == categoryName).FirstOrDefault().Topics.ToList().Insert(0, topic);

      return topic;
    }

    public void Update(string categoryName, string topicTitle, Topic topic)
    {
      throw new NotImplementedException();
    }

    public void Remove(string categoryName, string topicTitle)
    {
      throw new NotImplementedException();
    }

    #endregion

    #region Comments

    public List<Comment> GetComments(string categoryName, string topicTitle)
    {
      throw new NotImplementedException();
    }

    public Comment Get(string categoryName, string topicTitle, string commentId)
    {
      throw new NotImplementedException();
    }

    public Comment Create(string categoryName, string topicTitle, Comment comment)
    {
      throw new NotImplementedException();
    }

    public void Update(string categoryName, string topicTitle, Comment comment)
    {
      throw new NotImplementedException();
    }

    public void Remove(string categoryName, string topicTitle, string commentId)
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}
