using AssessmentApp.Domain.Domain;
using AssessmentApp.Services.DTOs;

namespace AssessmentApp.Services.Extensions
{
    public static class ExtensionDTOs
    {
        public static VeiculoDTO FromModel(this Veiculo veiculo)
        {
            return new VeiculoDTO
            {
                Id = veiculo.Id,
                Chassi = veiculo.Chassi,
                Placa = veiculo.Placa,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                AnoFabricacao = veiculo.AnoFabricacao,
                AnoModelo = veiculo.AnoModelo,
                ValorTabelaFipe = veiculo.ValorTabelaFipe,
                ValorVenda = veiculo.ValorVenda,
                Observacoes = veiculo.Observacoes
            };
        }

        public static Veiculo FromDTO(this VeiculoDTO veiculoDTO)
        {
            return new Veiculo
            {
                Id = veiculoDTO.Id,
                Chassi = veiculoDTO.Chassi,
                Placa = veiculoDTO.Placa,
                Marca = veiculoDTO.Marca,
                Modelo = veiculoDTO.Modelo,
                AnoFabricacao = veiculoDTO.AnoFabricacao,
                AnoModelo = veiculoDTO.AnoModelo,
                ValorTabelaFipe = veiculoDTO.ValorTabelaFipe,
                ValorVenda = veiculoDTO.ValorVenda,
                Observacoes = veiculoDTO.Observacoes
            };
        }
    }

}
