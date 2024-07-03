using HahnCargoSimBack.Services.CargoTransporter;
using HahnCargoSimBack.Services.Grid;
using HahnCargoSimBack.Services.Order;
using HahnCargoSimBack.Services.Sim;
using HahnCargoSimBack.Services.User;

namespace HahnCargoSimBack.Interfaces;

public class UnitOfService : IUniteOfService
{
      public ICargoTransporter CargoTransporter { get; }
        public IGrid Grid { get; }
        public IOrder Order { get; }
        public ISim Sim { get; }
        public IUser User { get; }

        public UnitOfService(
            ICargoTransporter cargoTransporter,
            IGrid grid,
            IOrder order,
            ISim sim,
            IUser user)
        {
            CargoTransporter = cargoTransporter;
            Grid = grid;
            Order = order;
            Sim = sim;
            User = user;
        }

}