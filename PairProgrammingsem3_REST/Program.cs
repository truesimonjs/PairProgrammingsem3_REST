using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using PairProgrammingsem3_REST.Interfaces;
using PairProgrammingsem3_REST.Repositories;
using System.Reflection;
using System.Text;

namespace PairProgrammingsem3_REST
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);
            
            // env coding
            var frontendOrigin = Environment.GetEnvironmentVariable("FRONTEND_ORIGIN");
            if (string.IsNullOrWhiteSpace(frontendOrigin)) //kigger efter en .env hvis frontendOrigin ikke kom fra github actions
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
                                              //policy.AllowAnyOrigin()
                                                    .WithMethods("GET", "POST", "DELETE")
                                                    .WithHeaders("Content-Type", "Authorization");
                                          });
            });

            var jwtSettings = builder.Configuration.GetSection("Jwt");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]!);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            builder.Services.AddAuthorization();


            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Indtast din JWT token"
                });

                opt.AddSecurityRequirement(doc => new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecuritySchemeReference("Bearer", doc),
                        new List<string>()
                    }
                });
            });


            // musicrecordRepo
            
            builder.Services.AddSingleton<IMusicRecordRepository,EFCMusicRecordRepository>();
            

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowFrontend");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
