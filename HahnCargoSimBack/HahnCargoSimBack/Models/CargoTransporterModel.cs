﻿namespace HahnCargoSimBack.Models;

public class CargoTransporterModel
{
    public int Id { get; set; }
    public int PositionNodeId { get; set; }
    public bool InTransit { get; set; }
    public int Capacity { get; set; }
    public int Load { get; set; }
    public List<Order> LoadedOrders { get; set; }
}