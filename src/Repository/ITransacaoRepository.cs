namespace crebito.Repository;

using crebito.Models;
using crebito.DTO;

public interface ITransacaoRepository
{
    Cliente GetCliente(int ClienteId);
    void Create(Transacao transacao);
    void UpdateCliente(Cliente cliente, int novoSaldo);
    IEnumerable<ExtratoDTOUltimasTransacoesBody> GetUltimasTransacoes(Cliente cliente);
}