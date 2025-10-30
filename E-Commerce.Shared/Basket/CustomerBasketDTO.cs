using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Shared.Basket;
public class CustomerBasketDTO
{
    [Required]
    public string Id { get; set; } 
    public ICollection<BasketItemDTO> Items { get; set; } = [];

}
