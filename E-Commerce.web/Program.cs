using E_Commerce.Domain.Contracts;
using E_Commerce.Infrastructure.Service;
using E_Commerce.Presistense.DependencyInjection;
using E_Commerce.Service.DependencyInjection;
using E_Commerce.web.Handler;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace E_Commerce.web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddApplicationServices()
                .AddPresistenceServices(builder.Configuration)
                .AddInfrastructureServices(builder.Configuration);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddExceptionHandler<NotFoundExceptionHandler>();
            builder.Services.AddProblemDetails();


            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState.Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key,
                    x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());

                    var problem = new ProblemDetails
                    {
                        Title = "Validation Error",
                        Detail = "One or more Validation errors occured",
                        Status = StatusCodes.Status400BadRequest,
                        Extensions = { { "error", errors } }
                    };

                    return new BadRequestObjectResult(problem);
                };
            });

            builder.Services.AddAuthentication(options =>
            {
                // Token => Bearer Sheme validation this token
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                // invalid token =>  401 unAutherized
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    var jwt = builder.Configuration.GetSection(JWTOptions.SectionName)
                    .Get<JWTOptions>();
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateLifetime = true,
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = jwt.Issuer,
                        ValidAudience = jwt.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key))

                    };
                });


            var app = builder.Build();

            var scope = app.Services.CreateScope();
            var initializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            await initializer.InitializeAsync();
            await initializer.InitializeAuthDbAsync();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseExceptionHandler();
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
