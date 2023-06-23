using CliWrap;
using LoftwareFixer;

const string ServiceName = "Loftware Fixer Service";

if(args is { Length: 1 })
{
    try
    {
        string executablePath =
            Path.Combine(AppContext.BaseDirectory, "App.WindowsService.exe");
        if (args[0] is "/Install")
        {
            await Cli.Wrap("sc")
                .WithArguments(new[] { "create", ServiceName, $"binPath={executablePath}", "start=auto" })
                .ExecuteAsync();
        }
        else if (args[0] is "/Uninstall")
        {
            await Cli.Wrap("sc")
                .WithArguments(new[] { "stop", ServiceName })
                .ExecuteAsync();

            await Cli.Wrap("sc")
                .WithArguments(new[] { "delete", ServiceName })
                .ExecuteAsync();
        }
    }
    catch(Exception es) { Console.WriteLine(es.Message); }
    return;
}

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options =>
    {
        options.ServiceName = "Loftware Fixer Service";
    })
    .ConfigureServices(services =>
    {
        services.AddHostedService<WorkerService>();
    })
    .Build();

await host.RunAsync();
