using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Shared.DataTransferObject.Basket;
public class CustomerBasketDTO
{
    [Required]
    public string Id { get; set; } 
    public ICollection<BasketItemDTO> Items { get; set; } = [];

}
