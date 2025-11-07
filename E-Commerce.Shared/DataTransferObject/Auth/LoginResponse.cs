using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Shared.DataTransferObject.Auth;
public record LoginResponse([EmailAddress] string Email, string Password);