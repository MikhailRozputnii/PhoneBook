using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.BusinessLogic.DTO;
using PhoneBook.BusinessLogic.Services.IdentityProvider;

namespace PhoneBook.BusinessLogic.Extensions
{
    public static class IdentityProviderExtensions
    {
        public static void AddCustomIdentityProvider(this IServiceCollection services)
        {
            services.AddTransient<IUserStore<UserDto>, UserStore>();
            services.AddTransient<ManageUsers>();
        }

    }
}
