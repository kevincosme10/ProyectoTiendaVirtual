using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using TiendaData.Interfaces.Base;
using TiendaData.Repository;
using TiendaEntities.Models;
using TiendaService.Base.BaseInterface;
using TiendaService.Service;
using TiendaService.ServiceInterface;

namespace Tienda
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
            /*services.AddIdentity<AplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<TiendaDataContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "yourdomain.com",
                    ValidAudience = "yourdomain.com",
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Configuration["llave_secreta"]))
                });*/

            var connectionString = Configuration["sqlconnection:connectionString"];

            var migrationAssembly = typeof(Startup).GetType().Assembly.GetName().Name;
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            services.AddDbContext<TiendaDataContext>(options =>
            {
                options.UseSqlServer(connectionString);

            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TiendaApi", Version = "v1" });
            });
            services.AddScoped<IServiceBase<Producto>, ProductoService>();
            services.AddScoped<IBaseRepository<Producto>, ProductoRepository>();
            services.AddScoped<IProductoService, ProductoService>();

            services.AddScoped<IServiceBase<usuario>, usuarioService>();
            services.AddScoped<IBaseRepository<usuario>, usuarioRepository>();
            services.AddScoped<Iusuario, usuarioService>();

            services.AddScoped<IServiceBase<opcionesMenu>, opcionesMenuService>();
            services.AddScoped<IBaseRepository<opcionesMenu>, opcionesMenuRepository>();
            services.AddScoped<IopcionesMenu, opcionesMenuService>();

            services.AddScoped<IServiceBase<perfilAccion>, perfilAccionService>();
            services.AddScoped<IBaseRepository<perfilAccion>, perfilAccionRepository>();
            services.AddScoped<IperfilAccion, perfilAccionService>();

            services.AddScoped<IServiceBase<perfilUsuario>, perfilUsuarioService>();
            services.AddScoped<IBaseRepository<perfilUsuario>, perfilUsuarioRepository>();
            services.AddScoped<IperfilUsuario, perfilUsuarioService>();


            var mapper = Infraestructura.Mapping.MappingEntity.GetMapper();
            services.AddSingleton(mapper);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors("CorsPolicy");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
