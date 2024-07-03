using HahnCargoSimBack.Models;

namespace HahnCargoSimBack.Services.CargoTransporter;

public interface ICargoTransporter
{
    int Buy(int positionNodeId);
    CargoTransporterModel Get(int transporterId);
    void Move(int transporterId, int targetNodeId);
}