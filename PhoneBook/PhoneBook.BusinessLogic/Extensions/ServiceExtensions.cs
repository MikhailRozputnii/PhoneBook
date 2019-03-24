using Microsoft.Extensions.DependencyInjection;
using PhoneBook.BusinessLogic.Contracts;
using PhoneBook.BusinessLogic.Services;

namespace PhoneBook.BusinessLogic.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddPhoneService(this IServiceCollection services)
        {
            services.AddScoped<IPhoneService, PhoneService>();
        }
    }
}
