using cqrs_vanilla.Infrastructure.Services;

namespace cqrs_vanilla.Infrastructure.Extensions;

public static class CQRSExtension
{
    public static void AddCQRS(this IServiceCollection services)
    {
        // INFO: Using https://www.nuget.org/packages/Scrutor for registering all Query and Command handlers by convention
        
        services.Scan(selector =>
        {
            selector.FromCallingAssembly().AddClasses(filter =>
            {
                filter.AssignableTo(typeof(IQueryHandler<,>));
            })
            .AsImplementedInterfaces()
            .WithScopedLifetime();
        });
            
        services.Scan(selector =>
        {
            selector.FromCallingAssembly().AddClasses(filter =>
            {
                filter.AssignableTo(typeof(ICommandHandler<,>));
            })
            .AsImplementedInterfaces()
            .WithScopedLifetime();
        });
    }
}