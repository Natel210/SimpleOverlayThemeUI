using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: GenerateXamlTool --ini <iniFilePath> --output <outputXamlPath>");
            return;
        }

        string iniFilePath = args[1];
        string outputXamlPath = args[3];

        GenerateCurrentXaml(iniFilePath, outputXamlPath);
    }

    static void GenerateCurrentXaml(string iniFilePath, string outputXamlPath)
    {
        var iniData = LoadIniData(iniFilePath); // INI 데이터 로드
        var xamlBuilder = new StringBuilder();
        xamlBuilder.AppendLine("<ResourceDictionary xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"");
        xamlBuilder.AppendLine("                    xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\">");

        foreach (var kvp in iniData)
        {
            xamlBuilder.AppendLine($"    <SolidColorBrush x:Key=\"{kvp.Key}\" Color=\"{kvp.Value}\" />");
        }

        xamlBuilder.AppendLine("</ResourceDictionary>");
        File.WriteAllText(outputXamlPath, xamlBuilder.ToString());
    }

    static Dictionary<string, string> LoadIniData(string iniFilePath)
    {
        // INI 파일 로드 로직 구현
        return new Dictionary<string, string>
        {
            { "PrimaryColor", "#FF0000" },
            { "SecondaryColor", "#00FF00" }
        };
    }
}