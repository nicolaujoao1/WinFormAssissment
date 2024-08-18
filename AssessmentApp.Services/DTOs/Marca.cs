namespace AssessmentApp.Services.DTOs
{
    public class Marca
    {
        public string Codigo { get; set; } = default!;
        public string Nome { get; set; } = default!;
    }
    public class Modelo
    {
        public string Codigo { get; set; } = default!;
        public string Nome { get; set; } = default!;
    }
    public class ModelReponse
    {
        public List<Modelo> Modelos { get; set; } = default!;
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Token { get; set; } = default!;
    }

    public class AuthResponse
    {
        public bool Error { get; set; }
        public string Message { get; set; } = default!;
        public User User { get; set; } = default!;
    }
}
