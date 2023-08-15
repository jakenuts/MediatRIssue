using System.Reflection;
using MediatR;
using MediatRTest.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
    })
    .Build();

using var scope = host.Services.CreateScope();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
var publisher = scope.ServiceProvider.GetRequiredService<IPublisher>();

logger.LogInformation("📰 Publishing TestEventA");

await publisher.Publish(new TestEventA());

logger.LogInformation("📰 Publishing TestEventB");

await publisher.Publish(new TestEventB());

logger.LogInformation("🏁 Finished test...");