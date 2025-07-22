namespace ThemeXamlGenerator.Theme.XamlExporter.Internal
{
    internal interface IXamlExporterCore
    {
        /// <summary> get => deep copy, only view, don't able chanage items... </summary>
        System.IO.DirectoryInfo? RootPath { get; set; }

        /// <summary></summary>
        void Export(string name);

        /// <summary></summary>
        void ExportAll();
    }
}
