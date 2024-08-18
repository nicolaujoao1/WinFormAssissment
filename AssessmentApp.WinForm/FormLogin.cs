using AssessmentApp.Services.DTOs;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Text;
using IAuthService = AssessmentApp.Services.Services.IAuthService;

namespace AssessmentApp.WinForm
{
    public partial class FormLogin : Form
    {
        //private readonly IAuthService _authService;
        private readonly IServiceProvider _serviceProvider;
        public FormLogin(IServiceProvider serviceProvider)
        {
            //IAuthService authService,
            InitializeComponent();
            //_authService = authService;
            _serviceProvider = serviceProvider;
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            var user = txtUser.Text;
            var password = txtPassword.Text;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            try
            {
                using (var auth = _serviceProvider.CreateScope())
                {
                    var _authService = auth.ServiceProvider.GetRequiredService<IAuthService>();
                    var result = await _authService.AuthenticateUser(user, password);


                    if (!result.Error)
                    {
                        MessageBox.Show($"Bem-vindo, {result.User.Name}");
                        string token = result.User.Token;
                        var form = _serviceProvider.GetRequiredService<FormPrincipal>();
                        form.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show(result.Message);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private async Task<AuthResponse> AuthenticateUser(string user, string password)
        {
            var url = "https://test-api-y04b.onrender.com/signIn";
            using (var client = new HttpClient())
            {
                var payload = new
                {
                    user,
                    password
                };

                var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);
                var jsonResponse = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<AuthResponse>(jsonResponse)!;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}