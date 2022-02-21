using DebatableAPI.Models;

namespace DebatableAPI.Services
{
  public interface ICategoryService
  {
    #region Category

    List<Category> Get();
    Category Get(string name);
    Category Create(Category category);
    void Update(string name, Category category);
    void Remove(string name);

    #endregion

    #region Topic

    List<Topic> GetTopics(string categoryName);
    Topic Get(string categoryName, string topicTitle);
    Topic Create(string categoryName, Topic topic);
    void Update(string categoryName, string topicTitle, Topic topic);
    void Remove(string categoryName, string topicTitle);

    #endregion

    #region Comments
    
    List<Comment> GetComments(string categoryName, string topicTitle);
    Comment Get(string categoryName, string topicTitle, string commentId);
    Comment Create(string categoryName, string topicTitle, Comment comment);
    void Update(string categoryName, string topicTitle, Comment comment);
    void Remove(string categoryName, string topicTitle, string commentId);

    #endregion
  }
}
