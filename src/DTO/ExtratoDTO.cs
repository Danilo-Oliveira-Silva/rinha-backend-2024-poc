using System.Collections.ObjectModel;

namespace crebito.DTO;

public record ExtratoDTO {
    public int exception { get; set; }
    public ExtratoDTOBody? extratoResponse { get; set; }
}

public record ExtratoDTOBody {

    public ExtratoDTOSaldoBody? saldo { get; set; }
    public IEnumerable<ExtratoDTOUltimasTransacoesBody>? ultimas_transacoes { get; set; }
}

public record ExtratoDTOSaldoBody {
    public int total { get; set; }  
    public DateTime data_extrato { get; set; }
    public int limite { get; set; }
}

public record ExtratoDTOUltimasTransacoesBody {
    public int valor { get; set; }  
    public string? tipo { get; set; }
    public string? descricao { get; set; }
    public DateTime realizada_em { get; set; }
}