using CommandLine;
using VideoResize.Configuration;

namespace VideoResize;

public class Program
{
    public static async Task<int> Main(params string[] args)
    {
        return await Parser.Default.ParseArguments<CommandLineOptions>(args)
            .MapResult(async (CommandLineOptions opts) =>
            {
                try
                {
                    Console.WriteLine(opts.Path);
                    return await Task.FromResult(1);
                }
                catch
                {
                    return -3;
                }
            },
            errs => Task.FromResult(-1));
    }
}
