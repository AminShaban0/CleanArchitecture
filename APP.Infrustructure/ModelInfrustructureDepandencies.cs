using APP.Infrustructure.Abstract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Infrustructure
{
    public static class ModelInfrustructureDepandencies
    {
        public static IServiceCollection InfrusteuctureDepandencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            return services;
        }
    }
}
