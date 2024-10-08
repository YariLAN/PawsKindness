﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PawsKindness.Application.Services.Volunteers.CreateVolunteer;

namespace PawsKindness.Application;

public static class Inject
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICreateVolunteerService, CreateVolunteerService>();

        services.AddValidatorsFromAssembly(typeof(Inject).Assembly);

        return services;
    }
}