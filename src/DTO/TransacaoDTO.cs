namespace crebito.DTO;

public record TransacaoDTO {
    public int exception { get; set; }
    public TransacaoDTOBody? transacaoResponse { get; set; }
}

public record TransacaoDTOBody {
     public int limite { get; set; }
    public int saldo { get; set; }
}