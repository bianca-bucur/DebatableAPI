using DebatableAPI.Models;
using DebatableAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DebatableAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CategoryController : ControllerBase
  {
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
      _categoryService = categoryService;
    }

    #region Categories

    [HttpGet]
    public ActionResult<List<Category>> Get() =>
      _categoryService.Get();

    [HttpGet("{name}", Name = "GetCategory")]
    public ActionResult<Category> Get(string name)
    {
      var category = _categoryService.Get(name);

      if(category == null)
      {
        return NotFound();
      }

      return Ok(category);
    }

    [HttpPost(Name = "NewCategory")]
    public ActionResult<Category> Create(Category category)
    {
      _categoryService.Create(category);

      return CreatedAtRoute("GetCategory", new {name = category.Name.ToString()}, category);
    }

    [HttpPut("{name}")]
    public IActionResult Update(string name, Category categoryIn)
    {
      var category = _categoryService.Get(name);

      if(category == null)
      {
        return NotFound();
      }

      _categoryService.Update(name, categoryIn);

      return NoContent();
    }

    [HttpDelete("{name}")]
    public IActionResult Delete(string name)
    {
      var category = _categoryService.Get(name);

      if(category == null)
      {
        return NotFound();
      }

      _categoryService.Remove(name);

      return NoContent();
    }

    #endregion

    #region Topics

    [HttpPost("{name}")]
    public ActionResult<Topic> Create(string categoryName, Topic topic)
    {
      _categoryService.Create(categoryName, topic);

      return Ok();
    }

    #endregion
  }
}
