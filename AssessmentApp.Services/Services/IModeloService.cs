namespace AssessmentApp.Services.DTOs
{
    public interface IModeloService
    {
        Task<IEnumerable<Modelo>> ListarMarcasAsync(long marcaCodigo);
    }
}
