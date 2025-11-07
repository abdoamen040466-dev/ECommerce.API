namespace E_Commerce.Domain.Entities.Auth;
public class Address
{
    public ApplicationUser user { get; set; }
    public string UserId { get; set; }
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Country { get; set; }

}
