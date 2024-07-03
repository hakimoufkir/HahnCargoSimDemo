namespace HahnCargoSimBack.Services.Grid;

public interface IGrid
{
    string Get();
    void GenerateFile(int numberOfNodes, int numberOfEdges, int numberOfConnectionsPerNode, string filename);
}