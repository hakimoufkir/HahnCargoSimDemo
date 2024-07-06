namespace HahnCargoSimBack.Services.Grid;

public interface IGrid
{
    Task<string> Get(string token);
    Task GenerateFile(int numberOfNodes, int numberOfEdges, int numberOfConnectionsPerNode, string filename,string token);
}