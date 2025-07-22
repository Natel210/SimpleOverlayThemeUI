using System.IO;
using ThemeXamlGenerator.Theme.XamlExporter.Internal;

namespace ThemeXamlGenerator.Theme.XamlExporter
{
    /// <summary>
    /// Extand Theme System. <br/>
    /// Only Export XAML files.
    /// </summary>
    public class XamlExporter
    {

        /// <summary> get => deep copy, only view, don't able chanage items... </summary>
        static public DirectoryInfo? RootPath {
            get => XamlExporterCore.Instance.RootPath;
            set => XamlExporterCore.Instance.RootPath = value;
        }

        /// <summary></summary>
        static public void Export(string name) => XamlExporterCore.Instance.Export(name);

        /// <summary></summary>
        static public void ExportAll() => XamlExporterCore.Instance.ExportAll();

    }
}
