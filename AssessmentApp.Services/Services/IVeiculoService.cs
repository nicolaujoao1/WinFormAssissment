using AssessmentApp.Services.DTOs;

namespace AssessmentApp.Services.Services
{
    public interface IVeiculoService
    {
        Task<VeiculoDTO> BuscarPorId(long id);
        Task<IEnumerable<VeiculoDTO>> ListarVeiculos();
        Task<bool> Adicionar(VeiculoDTO veiculo);
        Task<bool> Editar(VeiculoDTO veiculo);
        Task<bool> Deletar(long id);
    }
}
