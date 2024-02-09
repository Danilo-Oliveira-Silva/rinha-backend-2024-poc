namespace crebito.Context;
using MongoDB.Driver;

public interface IContextConnection
{
    IMongoDatabase GetDatabase();
}