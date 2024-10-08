using FluentValidation.AspNetCore;
using PawsKindness.API.Extensions;
using PawsKindness.Application;
using PawsKindness.Infrastructure;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace PawsKindness.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services
            .AddInfrastructure()
            .AddApplication();

        builder.Services.AddFluentValidationAutoValidation(configuration =>
        {
            configuration.OverrideDefaultResultFactoryWith<CustomValidationResultFactory>();
        });

        var app = builder.Build();

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
