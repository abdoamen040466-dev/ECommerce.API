namespace E_Commerce.Shared.Basket;
public class BasketItemDTO
{
#nullable disable
    public string Id { get; set; }
    public string Name { get; set; }
    public string PictureUrl { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
