namespace E_Commerce.Shared.DataTransferObject.Products;
public class ProductQueryParameters
{
    public int? BrandId { get; set; }
    public int? TypeId { get; set; }
    public string? Search { get; set; }
    public ProductSortingOptions Sort { get; set; }

}
public enum ProductSortingOptions
{
    NameAscending = 1,
    NameDescending = 2,
    PriceAscending = 3,
    PriceDescending = 4,
}