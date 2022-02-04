using Microsoft.AspNetCore.Mvc;
using RoleBot.Infrastructure.Services.Interfaces;
namespace RoleBot.API.Controllers;

[Route("/api/[controller]/[action]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(long categoryId)
    {
        var result = await _categoryService.GetCategory(categoryId);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetGuildCategories(string guildId)
    {
        var result = await _categoryService.GetGuildCategories(guildId);

        return Ok(result);
    }
}
