namespace crebito.UseCase;

using crebito.Models;
using crebito.Repository;
using crebito.DTO;

public class TransacaoUseCase : ITransacaoUseCase
{
    private ITransacaoRepository _repository;
    public TransacaoUseCase(ITransacaoRepository repository)
    {
        _repository = repository;
    }

    public TransacaoDTO AddTransacao(Transacao transacao, int ClienteId)
    {
        if (transacao.tipo != "d" && transacao.tipo != "c") return new TransacaoDTO { exception = 2 };

        Cliente cliente = _repository.GetCliente(ClienteId);
        if (cliente == default) return new TransacaoDTO { exception = 1 };

        int novoSaldo = cliente.saldo;
        if (transacao.tipo == "d") novoSaldo -= transacao.valor;
        else novoSaldo += transacao.valor;
        
        if (cliente.limite + novoSaldo < 0) return new TransacaoDTO { exception = 2 };

        _repository.UpdateCliente(cliente, novoSaldo);

        transacao.realizada_em = DateTime.UtcNow;
        transacao.clienteid = cliente.clienteid;

        _repository.Create(transacao);

        return new TransacaoDTO { 
            exception = 0,
            transacaoResponse = new TransacaoDTOBody {
                limite = cliente.limite,
                saldo = novoSaldo,
            }
         };
        
    }
    public ExtratoDTO ListExtrato(int ClienteId)
    {
        Cliente cliente = _repository.GetCliente(ClienteId);
        if (cliente == default) return new ExtratoDTO { exception = 1 };
                
        return new ExtratoDTO { 
            exception = 0,
            extratoResponse = new ExtratoDTOBody {
                saldo = new ExtratoDTOSaldoBody {
                    total = cliente.saldo,
                    data_extrato = DateTime.UtcNow,
                    limite = cliente.limite
                },
                ultimas_transacoes = _repository.GetUltimasTransacoes(cliente)
            }
        };
    }
}