using AssessmentApp.Data.Context;
using AssessmentApp.Data.Repositories;
using AssessmentApp.Domain.Interfaces;
using AssessmentApp.Services.DTOs;
using AssessmentApp.Services.Services;
using AssessmentApp.WinForm.Consts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AssessmentApp.WinForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();

            var mainForm = serviceProvider.GetRequiredService<FormLogin>();
            Application.Run(mainForm);
        }
        private static IServiceCollection ConfigureServices()
        {

            var services = new ServiceCollection();

            // Configurar o DbContext com MySQL
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(ConnectionString.connectionString,
                    new MySqlServerVersion(new Version(8, 0, 23))));
            
            // Registrando HttpClient para os serviços
            services.AddHttpClient<IAuthService, AuthService>();
            services.AddHttpClient<IMarcaService, MarcaService>();
            services.AddHttpClient<IModeloService, ModeloService>();

            // Registrando os repositórios e serviços
            services.AddTransient<IVeiculoRepository, VeiculoRepository>();
            services.AddTransient<IVeiculoService, VeiculoService>();

            // Registrando os Formulários
            services.AddTransient<FormLogin>();
            services.AddTransient<FormPrincipal>();
            services.AddTransient<FormMarca>();
            services.AddTransient<FormModelo>();
            services.AddTransient<FormVeiculo>();

            return services;
        }

    }
}