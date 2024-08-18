using AssessmentApp.Domain.Domain;

namespace AssessmentApp.Domain.Interfaces
{
    public interface IVeiculoRepository
    {
        Task<Veiculo> BuscarPorId(long id);
        Task<IEnumerable<Veiculo>> ListarVeiculos();
        Task<bool> Adicionar(Veiculo veiculo);
        Task<bool> Editar(Veiculo veiculo);
        Task<bool> Deletar(long id);
    }
}
