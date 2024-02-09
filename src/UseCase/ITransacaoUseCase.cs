namespace crebito.UseCase;

using crebito.Models;
using crebito.DTO;

public interface ITransacaoUseCase
{
    TransacaoDTO AddTransacao(Transacao transacao, int ClienteId);
    ExtratoDTO ListExtrato(int ClienteId);
}