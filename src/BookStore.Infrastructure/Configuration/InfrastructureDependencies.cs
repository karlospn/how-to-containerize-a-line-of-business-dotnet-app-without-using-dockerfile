﻿using BookStore.Domain.Interfaces;
using BookStore.Domain.Services;
using BookStore.Infrastructure.Context;
using BookStore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InfrastructureDependencies
    {
        public static IServiceCollection RegisterInfrastureDependencies(this IServiceCollection services)
        {

            services.AddDbContext<BookStoreDbContext>(options =>
            {
                options.UseInMemoryDatabase("BookStoreDb");
            });

            services.AddScoped<BookStoreDbContext>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }
    }
}