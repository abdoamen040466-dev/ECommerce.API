namespace E_Commerce.Service.Exceptions;
public abstract class NotFoundException(string massage) : Exception(massage);

public sealed class ProductNotFoundException(int id) :
    NotFoundException($"Product With id {id} Not Found");

public sealed class BasketNotFoundException(string id) :
    NotFoundException($"Product With id {id} Not Found");