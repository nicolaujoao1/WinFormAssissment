namespace AssessmentApp.Services.DTOs
{
    public interface IMarcaService
    {
        Task<IEnumerable<Marca>> ListarMarcasAsync();
    }
}
