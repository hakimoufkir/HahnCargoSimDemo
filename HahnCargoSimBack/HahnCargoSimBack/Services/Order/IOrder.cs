namespace HahnCargoSimBack.Services.Order;

public interface IOrder
{
    Task<List<Order>> GetAllAvailable(string token);
    Task<List<Order>> GetAllAccepted(string token);
    Task Accept(int orderId,string token);
    Task Create(string token);
    Task GenerateFile(int maxTicks, string filename,string token);
    
}