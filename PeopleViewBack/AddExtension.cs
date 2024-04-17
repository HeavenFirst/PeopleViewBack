using PeopleViewBack.Interfaces;
using PeopleViewBack.Repositories;
using PeopleViewBack.Services;

namespace PeopleViewBack
{
    public static class AddExtension
    {
        public static void InjectDependencies(this IServiceCollection service)
        {
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
