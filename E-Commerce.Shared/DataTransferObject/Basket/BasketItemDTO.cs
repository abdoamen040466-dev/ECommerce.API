using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Shared.DataTransferObject.Basket;
public class BasketItemDTO
{
#nullable disable
    [Required]
    public string Id { get; set; }
    public string Name { get; set; }
    public string PictureUrl { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
