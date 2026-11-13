
using DotNetEnv;
using System.Reflection;

namespace PairProgrammingsem3_REST
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);
            
            // env coding
            var frontendOrigin = Environment.GetEnvironmentVariable("FRONTEND_ORIGIN");
            if (string.IsNullOrWhiteSpace(frontendOrigin)) //kører hvis frontendOrigin ikke kom fra github actions
            {
                var envFile = Path.Combine(
                builder.Environment.ContentRootPath,
                ".env");

                if (File.Exists(envFile))
                {
                    Env.Load(envFile);
                }
                frontendOrigin = Environment.GetEnvironmentVariable("FRONTEND_ORIGIN");
            }
            frontendOrigin ??= "http://127.0.0.1:5500";



            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                Console.WriteLine(frontendOrigin);
                options.AddPolicy(name: "AllowFrontend",
                                          policy =>
                                          {
                                             
                                              policy.WithOrigins(frontendOrigin)
                                                    .WithMethods("GET", "POST", "DELETE")
                                                    .WithHeaders("Content-Type", "Authorization");
                                          });
            });

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // musicrecordRepo
            MusicRecordRepository musicRepo = new();
            builder.Services.AddSingleton<IMusicRecordRepository>(musicRepo);
            musicRepo.AddTestData();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowFrontend");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
