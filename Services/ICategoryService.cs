using DebatableAPI.Models;

namespace DebatableAPI.Services
{
  public interface ICategoryService
  {
    List<Category> Get();
    Category Get(string name);
    Category Create(Category category);
    void Update(string name, Category category);
    void Remove(string name);
  }
}
