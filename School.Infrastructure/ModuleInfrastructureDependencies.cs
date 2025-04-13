using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using School.Infrastructure.Interfaces;
using School.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructre(this IServiceCollection service ,IConfiguration config)
        {
            service.AddTransient<IStudentRepository, StudentRepository>();
            return service;
        }
    }
}
