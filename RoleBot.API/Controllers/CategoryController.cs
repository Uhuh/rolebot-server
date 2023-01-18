using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rolebot.API.Dtos;
using RoleBot.API.Middleware;
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
    [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(long categoryId)
    {
        var result = await _categoryService.GetCategory(categoryId);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [JwtAuthorize]
    [HttpGet]
    [ProducesResponseType(typeof(List<CategoryDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetGuildCategories(string guildId)
    {
        var result = await _categoryService.GetGuildCategories(guildId);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}
