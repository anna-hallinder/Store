using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos.Customer;

public class LoginCustomerDto
{
   
    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}