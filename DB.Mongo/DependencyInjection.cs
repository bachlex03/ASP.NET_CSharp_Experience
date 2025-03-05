using DB.Mongo.Domain.Abstractions;
using DB.Mongo.Persistence.Repositories;

namespace DB.Mongo;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>(configuration.GetSection(MongoDbSettings.SettingKey));

        var log = typeof(MongoRepository<>);

        services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

        return services;
    }
}
