using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Category;
using Shared.Entities;
using Shared.Interfaces.IRepository;
using Shared.Interfaces.IService;

namespace Api.Apis;

public static class CategoryEndpoints
{
    public static void MapCategoryEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/categories");

        group.MapGet("/", async ([FromServices] ICategoryRepository categoryRepository) =>
        {
            var categories = await categoryRepository.GetAllCategoriesAsync();
            return Results.Ok(categories);
        });

        group.MapGet("/{id:guid}", async (Guid id, [FromServices] ICategoryRepository categoryRepository) =>
        {
            var category = await categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(category);
        });

        group.MapPost("/", async ([FromBody] CreateCategoryDto createCategoryDto, [FromServices] ICategoryRepository categoryRepository) =>
        {
            var category = new CategoryEntity
            {
                CategoryName = createCategoryDto.CategoryName
            };
            var createdCategory = await categoryRepository.CreateCategoryAsync(category);
            return Results.Created($"/api/categories/{createdCategory.CategoryId}", createdCategory);
        });

        group.MapPut("/{id:guid}", async (Guid id, [FromBody] UpdateCategoryDto updateCategoryDto, [FromServices] ICategoryRepository categoryRepository) =>
        {
            var category = await categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return Results.NotFound();
            }

            category.CategoryName = updateCategoryDto.CategoryName;

            var updatedCategory = await categoryRepository.UpdateCategoryAsync(category);
            return Results.Ok(updatedCategory);
        });

        group.MapDelete("/{id:guid}", async (Guid id, [FromServices] ICategoryRepository categoryRepository) =>
        {
            var result = await categoryRepository.DeleteCategoryAsync(id);
            if (!result)
            {
                return Results.NotFound();
            }
            return Results.NoContent();
        });

        group.MapGet("/search", async (string name, [FromServices] ICategoryRepository categoryRepository) =>
        {
            var categories = await categoryRepository.SearchCategoryByNameAsync(name);
            return Results.Ok(categories);
        });
    }
}
