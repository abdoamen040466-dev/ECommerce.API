namespace E_Commerc.ServiceAbstraction;
public interface ICashService
{
    Task<string?> GetAsync(string key);
    Task SetAsync(string key, object value, TimeSpan TTL);

}
