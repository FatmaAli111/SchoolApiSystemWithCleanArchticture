using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
                return service;

            }
        
    }
}
