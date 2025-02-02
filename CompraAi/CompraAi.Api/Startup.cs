using AutoMapper;
using CompraAi.Api.Mapeamentos;
using CompraAi.Repositorios;
using CompraAi.Repositorios.Interfaces;
using CompraAi.Servicos;
using CompraAi.Servicos.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CompraAi.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TodoAPI", Version = "v1" });
            });

            services.AddDbContext<Contexto>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IUsuarioServico, UsuarioServico>();

            services.AddScoped<IFamiliaServico, FamiliaServico>();
            services.AddScoped<IFamiliaRepositorio, FamiliaRepositorio>();

            services.AddScoped<IConviteServico, ConviteServico>();
            services.AddScoped<IConviteRepositorio, ConviteRepositorio>();

            services.AddScoped<IItemServico, ItemServico>();
            services.AddScoped<IItemRepositorio, ItemRepositorio>();

            services.AddScoped<IUsuarioFamiliaServico, UsuarioFamiliaServico>();
            services.AddScoped<IUsuarioFamiliaRepositorio, UsuarioFamiliaRepositorio>();

            services.AddScoped<IStatusServico, StatusServico>();
            services.AddScoped<IStatusRepositorio, StatusRepositorio>();

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Ativa o Swagger
            app.UseSwagger();

            // Ativa o Swagger UI
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Compra Ai V1");
                c.RoutePrefix = string.Empty;
            });

            RedirecionarParaSwaggerSeNecessario(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RedirecionarParaSwaggerSeNecessario(IApplicationBuilder app)
        {
            var option = new RewriteOptions();
            option.AddRedirect("(?i)swagger/", "/");
            app.UseRewriter(option);
        }
    }
}
