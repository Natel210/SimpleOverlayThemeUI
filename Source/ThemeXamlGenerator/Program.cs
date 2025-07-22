using System;
using System.Linq;
using ThemeXamlGenerator.Theme.Data;
using ThemeXamlGenerator.Theme.XamlExporter;

namespace ThemeXamlGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==== [ThemeXamlGenerator] Start ====");
            Console.WriteLine("  [Arguments]");
            if (args.Length != 2)
            {
                Console.WriteLine("  * Error Arguments");
                Console.WriteLine("    |- ThemeXamlGenerator.exe <ThemeJsonDir> <XamlOutputDir>");
                Console.WriteLine("==== [ThemeXamlGenerator] End ====");
                return;
            }
            ThemeDataGroup.RootPath = new(args[0]);
            XamlExporter.RootPath = new(args[1]);
            Console.WriteLine("  * arguments");
            Console.WriteLine($"    |- Theme Group Root Path : {ThemeDataGroup.RootPath}");
            Console.WriteLine($"    |- Xaml Exporter Root Path : {XamlExporter.RootPath}");
            Console.WriteLine("  [Discover]");
            ThemeDataGroup.DiscoverData();
            if (ThemeDataGroup.DataKeys().Count is 0)
            {
                Console.WriteLine($"  * not find themes, set default themes");
                ThemeDataGroup.SetDataToDefault();
                ThemeDataGroup.SaveDataAll();
            }
            else
                Console.WriteLine($"  * discover theme count ({ThemeDataGroup.DataKeys().Count})");
            Console.WriteLine($"  * theme list");
            ThemeDataGroup.DataKeys().ToList().ForEach(name => Console.WriteLine($"    |- {name}"));
            Console.WriteLine("  [Export]");
            XamlExporter.ExportAll();
            Console.WriteLine("==== [ThemeXamlGenerator] End ====");
        }
    }
}
