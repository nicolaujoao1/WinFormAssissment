using Newtonsoft.Json;

namespace AssessmentApp.Services.DTOs;
    public class MarcaService : IMarcaService
{
    private readonly HttpClient _httpClient;
    private string url = "https://parallelum.com.br/fipe/api/v1/carros/marcas";

    public MarcaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Marca>> ListarMarcasAsync()
    {
        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Marca>>(jsonResponse)!;
        }

        return Enumerable.Empty<Marca>();
    }
}
