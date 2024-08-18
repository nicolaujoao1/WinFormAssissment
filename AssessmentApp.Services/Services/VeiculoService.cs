using AssessmentApp.Domain.Interfaces;
using AssessmentApp.Services.DTOs;
using AssessmentApp.Services.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AssessmentApp.Services.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<bool> Adicionar(VeiculoDTO veiculo)
        {
            return await _veiculoRepository.Adicionar(veiculo.FromDTO());
        }

        public async Task<VeiculoDTO> BuscarPorId(long id)
        {
            return (await _veiculoRepository.BuscarPorId(id)).FromModel();
        }

        public async Task<bool> Deletar(long id)
        {
            return await _veiculoRepository.Deletar(id);
        }

        public async Task<bool> Editar(VeiculoDTO veiculo)
        {
            return await _veiculoRepository.Editar(veiculo.FromDTO());
        }

        public async Task<IEnumerable<VeiculoDTO>> ListarVeiculos()
        {
            var veiculos = await _veiculoRepository.ListarVeiculos();
            return veiculos.Select(veiculo => veiculo.FromModel());
        }
    }

}
