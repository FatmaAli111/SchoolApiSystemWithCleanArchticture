using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using School.Infrastructure.Interfaces;
using School.Infrastructure.Repository;
using School.Service.IServices;
using School.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Service
{
    public static class ModuleServiceDependencies
    {
        
            public static IServiceCollection AddModuleServiceDependencies(this IServiceCollection service, IConfiguration config)
            {
                service.AddTransient<IStudentService, StudentService>();
                return service;
            }
        
    }
}
