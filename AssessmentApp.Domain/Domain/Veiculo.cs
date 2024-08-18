namespace AssessmentApp.Domain.Domain
{
    public class Veiculo
    {
        public long Id { get; set; }
        public string Chassi { get; set; } = default!;
        public string Placa { get; set; } = default!;
        public string Marca { get; set; } = default!;
        public string Modelo { get; set; } = default!;
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
        public decimal ValorTabelaFipe { get; set; }
        public decimal ValorVenda { get; set; }
        public string Observacoes { get; set; } = default!;
    }
}
