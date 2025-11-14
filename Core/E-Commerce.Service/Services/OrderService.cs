using E_Commerc.ServiceAbstraction.Common;
using E_Commerce.Domain.Entities.OrderEntities;
using E_Commerce.Service.Specifications;
using E_Commerce.Shared.DataTransferObject.UserOrder;

namespace E_Commerce.Service.Services;
public class OrderService(IUnitOfWork unitOfWork,
    IMapper mapper,
    IBasketRepository basketRepository)
    : IOrderService
{
    public async Task<Result<OrderResponse>> CreateAsync(OrderRequest request, string email)
    {
        var basket = await basketRepository.GetAsync(request.BasketId);
        if (basket == null)
            return Error.NotFound("basket Not Found",
                $"basket with id {request.BasketId} was not found");
        var method = await unitOfWork.GetRepository<DeliveryMethod>()
            .GetByIdAsync(request.DeliveryMethodId);
        if (method == null)
            return Error.NotFound("Delevary Not Found",
                $"Delivery Method with id {request.DeliveryMethodId} was not found");

        var productRepo = unitOfWork.GetRepository<Product>();
        var ids = basket.Items.Select(i => i.Id).ToList();
        var products = (await productRepo.GetAllAsync(new GetProductByIdsSpecification(ids)))
            .ToDictionary(p => p.Id);

        var orderItems = new List<OrderItem>();

        var validationErrors = new List<Error>();

        foreach (var item in basket.Items)
        {
            if (!products.TryGetValue(item.Id, out Product? product))
            {
                validationErrors.Add(Error.Validation("product not found",
                    $"product with id {item.Id} from basket not found"));
                continue;
            }
            var orderItem = new OrderItem
            {
                Price = product.price,
                Quantity = item.Quantity,
                Product = new ProductInOrderItem
                {
                    Name = product.Name,
                    PictureUrl = product.PictureUrl,
                    ProductId = product.Id
                }
            };
            orderItems.Add(orderItem);
        }
        if (validationErrors.Any())
            return validationErrors;
        var subtotal = orderItems.Sum(i => i.Quantity * i.Price);
        var address = mapper.Map<OrderAddress>(request.Address);

        var order = new Order
        {
            DeliveryMethod = method,
            UserEmail = email,
            Items = orderItems,
            SubTotal = subtotal,
            Address = address,
        };

        var orderRepo = unitOfWork.GetRepository<Order, Guid>();
        orderRepo.Add(order);

        await unitOfWork.SaveChangesAsync();
        return mapper.Map<OrderResponse>(order);
    }

    public async Task<Result<List<OrderResponse>>> GetUserOrderAsync(string email)
    {
        var orderRepo = unitOfWork.GetRepository<Order, Guid>();
        var orders = (await orderRepo.GetAllAsync(new GetOrderByEmail(email)))
            .ToList();

        if (!orders.Any())
            return Error.NotFound("Orders Not Found",
                $"customer with email {email} doesn't have any orders");

        var response = mapper.Map<List<OrderResponse>>(orders);

        return response;
    }

    public async Task<Result<OrderResponse>> GetOrderByIdAsync(Guid id, string email)
    {
        var orderRepo = unitOfWork.GetRepository<Order, Guid>();
        var order = await orderRepo.GetAsync(new GetOrderByIdAndEmailSpecification(id, email));

        if (order == null)
            return Error.NotFound("Order Not Found",
                $"Order with id {id} was not found");
        return mapper.Map<OrderResponse>(order);
    }
    public async Task<Result<List<DeliveryMethodDTO>>> GetDeliveryMethodsAsync()
    {
        var methods = await unitOfWork.GetRepository<DeliveryMethod>()
            .GetAllAsync();

        if (methods.Any())
            return Error.NotFound("Delivery Methods Not Found", "Delivery Methods Not Found");

        return mapper.Map<List<DeliveryMethodDTO>>(methods);
    }

}
