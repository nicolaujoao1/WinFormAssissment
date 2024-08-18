using Newtonsoft.Json;

namespace AssessmentApp.Services.DTOs;

public class ModeloService : IModeloService
{
    private readonly HttpClient _httpClient;

    public ModeloService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Modelo>> ListarMarcasAsync(long marcaCodigo)
    {
        var response = await _httpClient.GetAsync($"https://parallelum.com.br/fipe/api/v1/carros/marcas/{marcaCodigo}/modelos");

        try
        {
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var carModelResponse = JsonConvert.DeserializeObject<ModelReponse>(jsonResponse);
                return carModelResponse?.Modelos ?? new List<Modelo>();
            }
            else
            {
                return Enumerable.Empty<Modelo>();
            }
        }
        catch (HttpRequestException ex)
        {

            throw new HttpRequestException(ex.Message);
        }

    }
}
