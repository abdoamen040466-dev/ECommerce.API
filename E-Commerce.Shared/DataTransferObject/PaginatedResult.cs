namespace E_Commerce.Shared.DataTransferObject;
public record PaginatedResult<TResult>(int PageIndex, int PageCount, int TotalCount, IEnumerable<TResult> Data);
