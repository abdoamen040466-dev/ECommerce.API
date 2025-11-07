using E_Commerce.Domain.Contracts;
using E_Commerce.Presistense.DependencyInjection;
using E_Commerce.Service.DependencyInjection;
using E_Commerce.web.Handler;
using Microsoft.AspNetCore.Mvc;

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
            builder.Services.AddApplicationServices();
            builder.Services.AddPresistenceServices(builder.Configuration);
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
