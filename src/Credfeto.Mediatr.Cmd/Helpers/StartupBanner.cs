using System;

namespace Credfeto.Mediatr.Cmd.Helpers;

internal static class StartupBanner
{
    /// <summary>
    ///     Display the program startup banner
    /// </summary>
    /// <remarks>Generated from https://www.coolgenerator.com/ascii-text-generator  Font: Basic</remarks>
    public static void Show()
    {
        const string banner = @"TEST";
        Console.WriteLine(banner);
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine($"{typeof(Program).Namespace}: Starting...");
        Console.WriteLine("");
    }
}