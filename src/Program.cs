using CommandLine;
using Microsoft.Extensions.Logging;
using VideoResize.Configuration;

namespace VideoResize;

public class Program
{
    public static async Task<int> Main(params string[] args)
    {
        var logger = CreateLogger();

        return await Parser.Default.ParseArguments<CommandLineOptions>(args)
            .MapResult(async (CommandLineOptions opts) =>
            {
                try
                {
                    logger.LogInformation("Application started for Path: {0}, using Recursive: {1}", opts.Path, opts.Recursive);
                    return await Task.FromResult(1);
                }
                catch(Exception ex)
                {
                    logger.LogError(ex, "Unexpected exception!");
                    return -3;
                }
            },
            errs => Task.FromResult(-1));
    }

    private static ILogger CreateLogger()
    {
        using var loggerFactory = LoggerFactory.Create(b =>
                {
                    b
                    .AddConsole();
                });

        return loggerFactory.CreateLogger<Program>();
    }
}
