﻿using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Contracts;
using PhoneBook.Repositories.Service;

namespace PhoneBook.Repositories.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
