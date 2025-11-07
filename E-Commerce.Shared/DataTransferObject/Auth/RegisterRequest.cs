using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Shared.DataTransferObject.Auth;
public record RegisterRequest([EmailAddress] string Email, string DisplayName, string Password,
    string? UserName = "MMM", string? PhoneNumber = "");