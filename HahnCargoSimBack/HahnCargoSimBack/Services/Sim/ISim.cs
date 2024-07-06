namespace HahnCargoSimBack.Services.Sim;

public interface ISim
{
    Task  Start(string token);
    Task  Stop(string token);
}