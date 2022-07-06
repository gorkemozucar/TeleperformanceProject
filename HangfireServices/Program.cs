using Hangfire;
using HangfireService;
using HangfireService.Services;
using HangfireServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostcontext, services) =>
    {
        services.AddHangfire(conf =>
        {
            conf.UseSqlServerStorage(hostcontext.Configuration.GetConnectionString("Default"));
        });
        services.AddHangfireServer();
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(hostcontext.Configuration.GetConnectionString("Default"));
        }, ServiceLifetime.Singleton);
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
