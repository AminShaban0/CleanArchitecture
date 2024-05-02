using APP.Infrustructure;
using APP.Infrustructure.Abstract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace APP.Core
{
    public static class ModelCoreDependencies
    {
        public static IServiceCollection CoreDependencies(this IServiceCollection services)
        {

            //services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(ModelCoreDependencies).Assembly));
            services.AddMediatR(ctf => ctf.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());




            return services;

        }
    }
}
