using HahnCargoSimBack.Models;

namespace HahnCargoSimBack.Services.CargoTransporter;

public class CargoTransporter : ICargoTransporter
{
    public int Buy(int positionNodeId)
    {
        return 99;
    }

    public CargoTransporterModel Get(int transporterId)
    {
        throw new NotImplementedException();
    }

    public void Move(int transporterId, int targetNodeId)
    {
        throw new NotImplementedException();
    }
}