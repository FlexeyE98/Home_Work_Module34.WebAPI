
using Microsoft.OpenApi.Models;
using ModuleWebAPI.Configuration;
using System.Reflection;

namespace ModuleWebAPI
{
    public class Program
    {
        public static IConfiguration Configuration
        { get; } = new ConfigurationBuilder()
            .AddJsonFile("HomeOptions.json")
            .Build();
        public static void Main(string[] args)
        {
 


        var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<HomeOptions>(Program.Configuration);
            builder.Services.Configure<Address>(Configuration.GetSection("Address"));
          

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c => 
            
            c.SwaggerDoc("v1", new OpenApiInfo { 
            Title = "HomeApi",
            Version = "v1"
            
            }));

            var assembly = Assembly.GetAssembly(typeof(MappingProfile));
            builder.Services.AddAutoMapper(assembly);



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

    }
}
