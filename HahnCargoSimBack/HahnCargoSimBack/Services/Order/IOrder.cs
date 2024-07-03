namespace HahnCargoSimBack.Services.Order;

public interface IOrder
{
    Order GetAllAvailable();
    Order GetAllAccepted();
    void Accept(int orderId);
    void Create();
    void GenerateFile(int maxTicks, string filename);
    
}