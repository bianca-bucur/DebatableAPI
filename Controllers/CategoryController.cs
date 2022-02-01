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

    [HttpGet]
    public ActionResult<List<Category>> Get() =>
      _categoryService.Get();
  }
}
