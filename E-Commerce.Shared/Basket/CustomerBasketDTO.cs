namespace E_Commerce.Shared.Basket;
public class CustomerBasketDTO
{
    public string Id { get; set; } 
    public ICollection<BasketItemDTO> Items { get; set; } = [];

}
