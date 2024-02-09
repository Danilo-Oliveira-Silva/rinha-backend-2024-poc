namespace crebito.Context;
using MongoDB.Driver;

public class ContextConnection : IContextConnection
{

    private MongoClient _client = null!;
    private string ConnectionString = "";
    private string DatabaseName = "";

    public ContextConnection()
    {
        Connect();   
    }

    public IMongoDatabase GetDatabase() {
        /*if (_client.Cluster.Description.State == MongoDB.Driver.Core.Clusters.ClusterState.Disconnected) 
        {
            Connect();
        }*/
        return _client.GetDatabase(DatabaseName);
    }

    private void Connect()
    {
        //ConnectionString = "mongodb://root:MyPassword123!@localhost:27017";
        //DatabaseName = "Crebito";
        ConnectionString = Environment.GetEnvironmentVariable("MONGO_CONNECTION")!;
        DatabaseName = Environment.GetEnvironmentVariable("MONGO_DATABASE")!;
        _client = new MongoClient(ConnectionString);
    }
}