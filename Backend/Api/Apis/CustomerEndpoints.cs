

using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Customer;
using Shared.Entities;
using Shared.Interfaces.IRepository;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/customers");

        group.MapGet("/", async ([FromServices] ICustomerRepository customerRepository) =>
        {
            var customers = await customerRepository.GetAllCustomersAsync();
            return Results.Ok(customers);
        });

        group.MapGet("/{id:guid}", async (Guid id, [FromServices] ICustomerRepository customerRepository) =>
        {
            var customer = await customerRepository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(customer);
        });

        group.MapPost("/", async ([FromBody] CreateCustomerDto createCustomerDto, [FromServices] ICustomerRepository customerRepository) =>
        {
            var customer = new CustomerEntity
            {
                FirstName = createCustomerDto.FirstName,
                LastName = createCustomerDto.LastName,
                Email = createCustomerDto.Email,
                Password = createCustomerDto.Password,
                Phone = createCustomerDto.Phone,
                Address = createCustomerDto.Address,
                PostalCode = createCustomerDto.PostalCode,
                City = createCustomerDto.City,
                Country = createCustomerDto.Country
            };

            var createdCustomer = await customerRepository.CreateCustomerAsync(customer);
            return Results.Created($"/api/customers/{createdCustomer.CustomerId}", createdCustomer);
        });

        group.MapPut("/{id:guid}", async (Guid id, [FromBody] UpdateCustomerDto updateCustomerDto, [FromServices] ICustomerRepository customerRepository) =>
        {
            var customer = await customerRepository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return Results.NotFound();
            }

            customer.FirstName = updateCustomerDto.FirstName;
            customer.LastName = updateCustomerDto.LastName;
            customer.Email = updateCustomerDto.Email;
            customer.Password = updateCustomerDto.Password;
            customer.Phone = updateCustomerDto.Phone;
            customer.Address = updateCustomerDto.Address;
            customer.PostalCode = updateCustomerDto.PostalCode;
            customer.City = updateCustomerDto.City;
            customer.Country = updateCustomerDto.Country;

            var updatedCustomer = await customerRepository.UpdateCustomerAsync(customer);
            return Results.Ok(updatedCustomer);
        });

        group.MapDelete("/{id:guid}", async (Guid id, [FromServices] ICustomerRepository customerRepository) =>
        {
            var result = await customerRepository.DeleteCustomerAsync(id);
            if (!result)
            {
                return Results.NotFound();
            }
            return Results.NoContent();
        });

        group.MapGet("/search", async (string email, [FromServices] ICustomerRepository customerRepository) =>
        {
            var customers = await customerRepository.SearchCustomersByEmailAsync(email);
            return Results.Ok(customers);
        });
    }
}
