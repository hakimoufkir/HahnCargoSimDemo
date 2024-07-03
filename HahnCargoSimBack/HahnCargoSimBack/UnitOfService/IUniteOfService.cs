using HahnCargoSimBack.Services.CargoTransporter;
using HahnCargoSimBack.Services.Grid;
using HahnCargoSimBack.Services.Order;
using HahnCargoSimBack.Services.Sim;
using HahnCargoSimBack.Services.User;

namespace HahnCargoSimBack.Interfaces;

public interface IUniteOfService
{
    ICargoTransporter CargoTransporter { get; }
    IGrid Grid { get; }
    IOrder Order { get; }
    ISim Sim { get; }
    IUser User { get; }
    
}