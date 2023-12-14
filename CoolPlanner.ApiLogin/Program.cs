using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Plantoufle.Repository;
using System.Security.Claims;

namespace CoolPlanner.ApiLogin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.AddServiceDefaults();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

            builder.Services.AddSingleton<IConfiguration>(configuration);
            builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            //builder.Services.AddSingleton(typeof(MyDbContext));

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<MyDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
            builder.Services.AddAuthorizationBuilder();

            builder.Services.AddIdentityCore<ConnectedUser>()
                .AddEntityFrameworkStores<MyDbContext>()
                .AddApiEndpoints();

           // builder.Services
           //.AddIdentityApiEndpoints<User>()
           //.AddEntityFrameworkStores<MyDbContext>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();
            app.MapDefaultEndpoints();
            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            app.UseSwagger();
                app.UseSwaggerUI();
            //}

            // Injectez le service de base de donn�es dans le scope actuel.
            using (var serviceScope = app.Services.CreateScope())
            {
                var serviceProvider = serviceScope.ServiceProvider;
                try
                {
                    var dbContext = serviceProvider.GetRequiredService<MyDbContext>();

                    // Appliquez les migrations si n�cessaire.
                    dbContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Une erreur s'est produite lors de l'application des migrations : " + ex.Message);
                }
            }

            app.MapIdentityApi<ConnectedUser>();

            app.MapGet("/", (ClaimsPrincipal user) => $"Hello {user.Identity!.Name}").RequireAuthorization();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
