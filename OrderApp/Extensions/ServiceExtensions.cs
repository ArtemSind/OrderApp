﻿using Microsoft.Extensions.DependencyInjection;
using OrderApp.BLL.Interfaces;
using OrderApp.BLL.Services;
using OrderApp.Interfaces;
using OrderApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureOrderRepository(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
        }

        public static void ConfigureOrderService(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
