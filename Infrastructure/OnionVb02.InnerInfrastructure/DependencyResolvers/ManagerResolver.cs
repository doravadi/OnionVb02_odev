using Microsoft.Extensions.DependencyInjection;
using OnionVb02.Application.ManagerInterfaces;
using OnionVb02.InnerInfrastructure.ManagerConcretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.InnerInfrastructure.DependencyResolvers
{

    public static class ManagerResolver
    {
        public static void AddManagerService(this IServiceCollection services)
        {
            services.AddScoped<IAppUserManager, AppUserManager>();
            services.AddScoped<IAppUserProfileManager, AppUserProfileManager>();
            services.AddScoped<ICategoryManager,CategoryManager>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IOrderDetailManager,OrderDetailManager>();
        }
    }
}
