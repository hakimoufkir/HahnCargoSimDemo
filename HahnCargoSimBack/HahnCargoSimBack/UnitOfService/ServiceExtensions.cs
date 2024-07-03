using HahnCargoSimBack.Services.CargoTransporter;
using HahnCargoSimBack.Services.Grid;
using HahnCargoSimBack.Services.Order;
using HahnCargoSimBack.Services.Sim;
using HahnCargoSimBack.Services.User;

namespace HahnCargoSimBack.Interfaces;

public static  class ServiceExtensions
{
    public static void AddUnitOfService(this IServiceCollection services)
    {
        // Register individual services
        services.AddScoped<ICargoTransporter, CargoTransporter>();
        services.AddScoped<IGrid, Grid>();
        services.AddScoped<IOrder, Order>();
        services.AddScoped<ISim, Sim>();
        services.AddScoped<IUser, User>();

        // Register UnitOfService with its interface
        services.AddScoped<IUniteOfService, UnitOfService>();
    }
}