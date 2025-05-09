using SimpleOverlayTheme.Ini2Xaml;

if (args.Length != 2)
{
    Console.Error.WriteLine("[Error] need arguments ... <input.ini> <output.xaml>");
    return 1;
}

var iniPath = args[0];
var xamlPath = args[1];

try
{
    Ini2Xaml.SetSourcePathProperty(iniPath);
    bool isLoad = Ini2Xaml.Execute(new FileInfo(xamlPath));
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