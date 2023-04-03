using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FluentResults;
using Incidents.DAL.Repositories.Interfaces.Base;
using Incidents.BLL.MediatR.Contact.GetByName;
using Incidents.DAL.Repositories.Realizations.Base;
using Incidents.BLL.DTO;
using Incidents.DAL.Entities;

namespace Incidents.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddTransient<IRequestHandler<GetInfoQuery, Result<InfoDTO>>, GetQestionnaireHandler>();

            var currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            services.AddAutoMapper(currentAssemblies);
            services.AddMediatR(currentAssemblies);
        }

        public static void AddApplicationServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            });
           
            services.AddMvc();

            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin();
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.SetPreflightMaxAge(TimeSpan.FromDays(1));
                });
            });

            services.AddControllers();
        }
    }
}
