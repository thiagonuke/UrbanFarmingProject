using UrbanFarming.Data.Repositories;
using UrbanFarming.Domain.Interfaces.Repositories;

namespace UrbanFarming.IoC.Modules
{
    public class RepositoryModule
    {
        public static void InjectDependencies(IServiceCollection services)
        {
            services.AddTransient<ILoginRepository, LoginRepository>();
        }
    }
}
