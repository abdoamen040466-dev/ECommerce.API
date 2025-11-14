namespace E_Commerce.Domain.Entities.OrderEntities;
public class Order : Entity<Guid>
{
    public ICollection<OrderItem> Items { get; set; } = [];
    public DeliveryMethod? DeliveryMethod { get; set; }
    public int? DeliveryMethodId { get; set; }
    public decimal SubTotal { get; set; }
    public string UserEmail { get; set; } = default!;
    public OrderAddress Address { get; set; } = default!;
    public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
    public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
    public string PaymentIntentId { get; set; } = string.Empty;
}

public class OrderAddress
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}