using ELearningApi.Infrustructure.Base;
using Microsoft.Extensions.DependencyInjection;

namespace ELearningApi.Infrustructure;

public static class ModuleInfrastructureDependencies
{
    public static void AddInfrastructureDependencies(this IServiceCollection services)
    {
        // Register UnitOfWork and GenericRepository
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    }
}