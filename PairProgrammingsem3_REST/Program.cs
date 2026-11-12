
using System.Reflection;

namespace PairProgrammingsem3_REST
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.

            builder.Services.AddCors(options =>
            {

                options.AddPolicy(name: "AllowFrontend",
                                          policy =>
                                          {
                                              const string LOCALHOST = "http://127.0.0.1:5500";
                                              policy.WithOrigins(LOCALHOST)
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
