// See https://aka.ms/new-console-template for more information
// Entry point for the SimpleOverlayTheme.XamlGen CLI tool.
// Converts a current.ini theme definition file into a valid WPF-compatible ResourceDictionary XAML file.

using SimpleOverlayTheme.CurrentThemeGeneraterToXaml;

if (args.Length != 2)
{
    Console.Error.WriteLine("[Error] need arguments ... <input.ini> <output.xaml>");
    return 1;
}

var iniPath = args[0];
var xamlPath = args[1];

try
{
    XamlConverter.SetSourcePathProperty(iniPath);
    bool isLoad = XamlConverter.Execute(new FileInfo(xamlPath));
    if (isLoad is true)
    {
        Console.WriteLine($"[Success] ini to xaml conversion.");
        Console.WriteLine($"Xaml Path => {xamlPath}");
    }
    else
    {
        Console.WriteLine($"[Success] created xaml from default.");
        Console.WriteLine($"Xaml Path => {xamlPath}");
    }
    return 0;
}
catch (Exception ex)
{
    Console.Error.WriteLine($"[Error] call message => {ex.Message}");
    return 1;
}