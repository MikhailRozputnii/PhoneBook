using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Repositories.Data;

namespace PhoneBook.Repositories.Extensions
{
    public static class PhoneBookDbExtensions
    {
        public static void AddPhoneBookDbContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<PhoneBookDbContext>(options => options
              .UseSqlServer(config.GetConnectionString("DefaultConnection")));
        }
    }
}
