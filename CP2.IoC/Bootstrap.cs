using CP2.Application.Services;
using CP2.Data.AppData;
using CP2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CP2.IoC
{
    public static class Bootstrap
    {
        public static void Start(IServiceCollection services, IConfiguration configuration)
        {
            // Configuração do DbContext com Oracle
            services.AddDbContext<ApplicationContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseOracle(connectionString, oracleOptions =>
                {
                    // Configurações adicionais, como timeout, se necessário
                    oracleOptions.CommandTimeout(60); // Exemplo de configuração de timeout
                });
            });

            // Repositórios
            services.AddTransient<IFornecedorRepository, FornecedorRepository>();
            services.AddTransient<IVendedorRepository, VendedorRepository>();

            // Serviços de aplicação
            services.AddTransient<IFornecedorApplicationService, FornecedorApplicationService>();
            services.AddTransient<IVendedorApplicationService, VendedorApplicationService>();
        }
    }
}
