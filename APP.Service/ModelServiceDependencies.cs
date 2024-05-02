using APP.Service.Abstracts;
using APP.Service.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Service
{
    public static class ModelServiceDependencies
    {
        public static IServiceCollection ServiceDependencies (this IServiceCollection services)
        {
            services.AddScoped(typeof(IDepartmentService),typeof(DepartmentService));
            services.AddScoped(typeof(IEmployeeService), typeof(EmployeeService));
            return services;
        }
    }
}
