
using Microsoft.EntityFrameworkCore;
using ProjectHive.API.Data;
using ProjectHive.API.Mapping;
using ProjectHive.API.Services;

namespace ProjectHive.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            }); ;
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ProjectHiveDbContext>(options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectHiveConnectionString")).UseLazyLoadingProxies());

            builder.Services.AddScoped<IProjectTrackerService, ProjectTrackerService>();
            builder.Services.AddScoped<IAccountListService, AccountListService>();
            builder.Services.AddScoped<IVerticalListService, VerticalListService>();
            builder.Services.AddScoped<IStatusListService, StatusListService>();
            builder.Services.AddScoped<IGeographyLocationService, GeographyLocationService>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowedSpecificOrigin",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:5173")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                    });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("AllowedSpecificOrigin");
            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
