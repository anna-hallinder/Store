using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Product;
using Shared.Entities;
using Shared.Interfaces.IRepository;
using Shared.Interfaces.IService;

namespace Api.Apis;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/products");

        group.MapGet("/", async ([FromServices] IProductRepository productRepository) =>
        {
            var products = await productRepository.GetAllProductsAsync();
            return Results.Ok(products);
        });

        group.MapGet("/{id:guid}", async (Guid id, [FromServices] IProductRepository productRepository) =>
        {
            var product = await productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(product);
        });

        group.MapPost("/", async ([FromBody] CreateProductDto createProductDto, [FromServices] IProductRepository productRepository) =>
        {
            var product = new ProductEntity
            {
                ProductArticleNumber = createProductDto.ProductArticleNumber,
                ProductName = createProductDto.ProductName,
                ProductDescription = createProductDto.ProductDescription,
                ProductUnitPrice = createProductDto.ProductUnitPrice,
                CategoryId = createProductDto.CategoryId,
                Status = createProductDto.Status
            };
            var createdProduct = await productRepository.CreateProductAsync(product);
            return Results.Created($"/api/products/{createdProduct.ProductId}", createdProduct);
        });

        group.MapPut("/{id:guid}", async (Guid id, [FromBody] UpdateProductDto updateProductDto, [FromServices] IProductRepository productRepository) =>
        {
            var product = await productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return Results.NotFound();
            }

            product.ProductArticleNumber = updateProductDto.ProductArticleNumber;
            product.ProductName = updateProductDto.ProductName;
            product.ProductDescription = updateProductDto.ProductDescription;
            product.ProductUnitPrice = updateProductDto.ProductUnitPrice;
            product.CategoryId = updateProductDto.CategoryId;
            product.Status = updateProductDto.Status;

            var updatedProduct = await productRepository.UpdateProductAsync(product);
            return Results.Ok(updatedProduct);
        });

        group.MapDelete("/{id:guid}", async (Guid id, [FromServices] IProductRepository productRepository) =>
        {
            var result = await productRepository.DeleteProductAsync(id);
            if (!result)
            {
                return Results.NotFound();
            }
            return Results.NoContent();
        });

        group.MapGet("/search", async (string name, [FromServices] IProductRepository productRepository) =>
        {
            var products = await productRepository.SearchProductByNameAsync(name);
            return Results.Ok(products);
        });

        group.MapGet("/search-by-article-number", async (string articleNumber, [FromServices] IProductRepository productRepository) =>
        {
            var products = await productRepository.SearchProductByArticleNumberAsync(articleNumber);
            return Results.Ok(products);
        });
    }
}
