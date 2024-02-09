namespace crebito.Repository;
using MongoDB.Driver;
using MongoDB.Bson;
using crebito.Context;
using crebito.Models;
using crebito.DTO;

public class TransacaoRepository : ITransacaoRepository
{
    private IMongoDatabase _database;
    public TransacaoRepository(IContextConnection contextConnection)
    {
        _database = contextConnection.GetDatabase();
    }

    public Cliente GetCliente(int ClienteId)
    {
        var filterCliente = Builders<Cliente>.Filter
                    .Eq(cliente => cliente.clienteid, ClienteId);
        var cliente = _database.GetCollection<Cliente>("clientes").Find(filterCliente).FirstOrDefault();
        return cliente;
    }

    public void UpdateCliente(Cliente cliente, int novoSaldo)
    {
        var filterCliente = Builders<Cliente>.Filter
                    .Eq(c => c.clienteid, cliente.clienteid);
        var updateCliente = Builders<Cliente>.Update
                        .Set(cliente => cliente.saldo, novoSaldo);
        _database.GetCollection<Cliente>("clientes").UpdateOne(filterCliente, updateCliente);
    }

    public void Create(Transacao transacao)
    {
        _database.GetCollection<Transacao>("transacoes").InsertOne(transacao);   
    }

    public IEnumerable<ExtratoDTOUltimasTransacoesBody> GetUltimasTransacoes(Cliente cliente)
    {
        var filterTransacoes = Builders<Transacao>.Filter
                    .Eq(transacao => transacao.clienteid, cliente.clienteid);
        var transacoes = _database.GetCollection<Transacao>("transacoes")
                        .Find(filterTransacoes)
                        .SortByDescending(t => t.realizada_em)
                        .Limit(10)
                        .ToList().Select(t => new ExtratoDTOUltimasTransacoesBody {
                            valor = t.valor,
                            tipo = t.tipo,
                            descricao = t.descricao,
                            realizada_em = t.realizada_em
                        });
        return transacoes;
    }
}