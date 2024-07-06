using HahnCargoSimBack.Models;

namespace HahnCargoSimBack.Services.CargoTransporter;

public interface ICargoTransporter
{
    Task<int> Buy(int positionNodeId,string token);
    Task<CargoTransporterModel> Get(int transporterId,string token);
    Task Move(int transporterId, int targetNodeId,string token);
}