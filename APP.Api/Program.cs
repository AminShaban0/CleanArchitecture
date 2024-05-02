
using APP.Core.Features.Employees.Queries.Handlers;
using APP.Core.Features.Employees.Queries.Models;
using APP.Infrustructure;
using APP.Infrustructure.Abstract;
using APP.Infrustructure.Data;
using APP.Service.Abstracts;
using APP.Service.Implementations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using APP.Service;
using APP.Core;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.Extensions.Options;

namespace APP.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<APPDbContext>(Options=>
            { Options.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection"));
                //Options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            //builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            builder.Services.InfrusteuctureDepandencies();
            builder.Services.CoreDependencies();
            builder.Services.ServiceDependencies();
            //builder.Services.AddScoped(typeof(IDepartmentService),typeof(DepartmentService));
            //builder.Services.AddScoped(typeof(IEmployeeService),typeof(EmployeeService));
            //builder.Services.AddMediatR(ctf => ctf.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            //builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
            //     typeof(GetAllEmployeeHandler).Assembly,
            //        typeof(GetAllEmployeesQuery).Assembly
            //    ));

            builder.Services.AddControllersWithViews();
            builder.Services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "";
            });

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                List<CultureInfo> supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("en-US"),
                        new CultureInfo("de-DE"),
                        new CultureInfo("fr-FR"),
                        new CultureInfo("ar-EG")
                     };

                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}