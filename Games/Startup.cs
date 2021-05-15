using Games.BL.Contracts;
using Games.BL.Implementations;
using Games.DAL.Entities;
using Games.DAL.Repositories.Contracts;
using Games.DAL.Repositories.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games
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
            services.AddControllers();

            //Aqui las inyecciones: Interfaz - Clase
            services.AddScoped<IUsuarioBL, UsuarioBL>();
            services.AddScoped<IJuegoBL, JuegoBL>();
            services.AddScoped<ICategoriaBL, CategoriaBL>();
            services.AddScoped<IPlataformaBL, PlataformaBL>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IJuegoRepository, JuegoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IPlataformaRepository, PlataformaRepository>();

            //Registro de contexto en el contenedor de dependencias
            services.AddDbContext<db_gamesContext>(opts => opts.UseMySql(Configuration["ConnectionString:GamesDB"]));

            //Para habilitar CORS en nuestra API
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
