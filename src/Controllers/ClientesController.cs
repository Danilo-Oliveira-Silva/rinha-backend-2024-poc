using crebito.DTO;
using crebito.Models;
using crebito.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace crebito.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientesController : ControllerBase
{
    private ITransacaoUseCase _useCase;
    public ClientesController(ITransacaoUseCase useCase)
    {
        _useCase = useCase;
    }
    [HttpPost("{ClienteId}/transacoes")]
    public IActionResult PostTransacao([FromBody] Transacao transacao, int ClienteId)
    {
        TransacaoDTO transacaoCreated = _useCase.AddTransacao(transacao, ClienteId);
        if (transacaoCreated.exception == 1) return NotFound( new { mensagem = "Cliente não encontrado" });
        if (transacaoCreated.exception == 2) return UnprocessableEntity( new { mensagem = "Erro no processamento"});
        return Ok(transacaoCreated.transacaoResponse);
    }

    [HttpGet("{ClienteId}/extrato")]
    public IActionResult GetExtrato(int ClienteId)
    {
        ExtratoDTO extrato = _useCase.ListExtrato(ClienteId);
        if (extrato.exception == 1) return NotFound( new { mensagem = "Cliente não encontrado" });
        return Ok(extrato.extratoResponse);
    } 
}