using CommandLine;

namespace VideoResize.Configuration;

public class CommandLineOptions
{
    [Value(index: 0, Required = true, HelpText = "Path to videos.")]
    public string Path { get; set; } = default!;

    [Option(shortName: 'r', longName: "recursive", Required = false, HelpText = "Recursively search videos", Default = true)]
    public bool Recursive { get; set; }
}
