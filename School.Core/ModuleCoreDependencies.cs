using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using School.Core.Behaviors;
using School.Core.Features.Students.Commands.Validators;
using School.Core.Features.Students.Mapping;
using School.Infrastructure.Interfaces;
using School.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace School.Core
{
    public static class ModuleCoreDependencies
    {
       
            public static IServiceCollection AddCoreDependencies(this IServiceCollection service)
            {
                service.AddMediatR(c=>c.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
                service.AddAutoMapper(typeof(StudentProfile).Assembly);

                service.AddValidatorsFromAssembly(typeof(AddStudentValidators).Assembly);
            service.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return service;

            }
        
    }
}
