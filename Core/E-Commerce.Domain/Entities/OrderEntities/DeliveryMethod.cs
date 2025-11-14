namespace E_Commerce.Domain.Entities.OrderEntities;
public class DeliveryMethod : Entity<int>
{
    public string ShortName { get; set; }
    public string Description { get; set; }
    public string DeliveryTime { get; set; }
    public int Price { get; set; }
}
