using Shared.Dtos.Customer;
using Shared.Interfaces.IRepository;

namespace Api.Apis;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/auth/login", async (LoginCustomerDto loginDto, ICustomerRepository customerRepository, ILogger<Program> logger) =>
        {
            // Logga e-post för felsökning
            logger.LogInformation("Attempting login for email: {Email}", loginDto.Email);

            // Hämta kunden från databasen
            var customer = await customerRepository.GetCustomerByEmailAsync(loginDto.Email);
            if (customer == null)
            {
                logger.LogWarning("Customer not found with email: {Email}", loginDto.Email);
                return Results.Unauthorized();
            }

            // Kontrollera lösenord
            if (customer.Password != loginDto.Password)
            {
                logger.LogWarning("Invalid password for email: {Email}", loginDto.Email);
                return Results.Unauthorized();
            }

            // Lösenord matchar, autentiseringen lyckades
            logger.LogInformation("Login successful for email: {Email}", loginDto.Email);

            // Här skulle du normalt generera en JWT eller liknande token
            return Results.Ok();
        });

        // Endpoint för att hämta kund baserat på e-post
        routes.MapGet("/api/customers/email/{email}", async (string email, ICustomerRepository customerRepository, ILogger<Program> logger) =>
        {
            logger.LogInformation("Fetching customer details for email: {Email}", email);
            var customer = await customerRepository.GetCustomerByEmailAsync(email);
            if (customer == null)
            {
                logger.LogWarning("Customer not found with email: {Email}", email);
                return Results.NotFound();
            }

            var customerDto = new ReadCustomerDto
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address,
                PostalCode = customer.PostalCode,
                City = customer.City,
                Country = customer.Country,
                OrderIds = customer.OrderIds
            };

            logger.LogInformation("Customer details fetched successfully for email: {Email}", email);
            return Results.Ok(customerDto);
        });
    }
}
