namespace E_Commerce.Shared.DataTransferObject.UserOrder;
public class OrderItemDTO
{
    public Guid Id { get; set; }
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string PictureUrl { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

}
