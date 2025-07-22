using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using ThemeXamlGenerator.Theme.Data;

namespace ThemeXamlGenerator.Theme.XamlExporter.Internal
{
    internal class XamlExporterCore : IXamlExporterCore
    {
        /// <summary></summary>
        static internal IXamlExporterCore Instance { get; } = new XamlExporterCore();
        private XamlExporterCore() { }

        private readonly Dictionary<string, XNamespace> namespaces = new() {
            { "xmlns", "http://schemas.microsoft.com/winfx/2006/xaml/presentation" },
            { "x", "http://schemas.microsoft.com/winfx/2006/xaml" },
            { "system", "clr-namespace:System;assembly=mscorlib" }
        };

        private DirectoryInfo? _rootPath = null;
        private readonly ReaderWriterLockSlim _rootPathLock = new();
        /// <summary> get => deep copy, only view, don't able chanage items... </summary>
        public DirectoryInfo? RootPath
        {
            get
            {
                _rootPathLock.EnterReadLock();
                try
                {
                    return _rootPath?.FullName is null ? null : new(_rootPath.FullName);
                }
                finally
                {
                    _rootPathLock.ExitReadLock();
                }
            }
            set
            {
                _rootPathLock.EnterReadLock();
                try
                {
                    _rootPath = value;
                }
                finally
                {
                    _rootPathLock.ExitReadLock();
                }
            }
        }

        /// <summary></summary>
        public void Export(string name)
        {
            if (RootPath is null)
            {
                throw new ArgumentNullException($"{nameof(RootPath)} is null.");
            }

            if (RootPath.Exists is false)
            {
                RootPath.Create();
            }

            File.WriteAllText(Path.Combine(RootPath.FullName, $"{name}.xaml"), MakeXaml(name, ThemeDataGroup.GetData_NullThrow(name)).ToString());
        }

        /// <summary></summary>
        public void ExportAll()
        {
            if (RootPath is null)
            {
                throw new ArgumentNullException($"{nameof(RootPath)} is null.");
            }

            if (RootPath.Exists is false)
            {
                RootPath.Create();
            }

            var keys = ThemeDataGroup.DataKeys();
            Parallel.ForEach(keys, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, name => { Export(name); });
        }


        private XElement MakeXaml(string name, IThemeData theme)
        {
            var xaml = new XElement(namespaces["xmlns"] + "ResourceDictionary",
                new XAttribute(XNamespace.Xmlns + "x", namespaces["x"]),
                new XAttribute(XNamespace.Xmlns + "system", namespaces["system"]));

            xaml.Add(new XComment(" ============================== "));
            xaml.Add(new XComment($" | * {name} Theme Dummy (Only Design View) * "));
            xaml.Add(new XComment($" | * Generated at {DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} * "));
            xaml.Add(new XComment(" ============================== "));

            var keys = theme.Keys();
            foreach (var key in keys)
            {
                var property = theme.Get(key);
                if (property is null)
                    continue;
                var element = new XElement(GetXName(property.Type),
                    new XAttribute(XName.Get("Key", "http://schemas.microsoft.com/winfx/2006/xaml"),
                    property.XamlKey), property.Value);
                if (element is not null)
                    xaml.Add(element);
            }
            return xaml;
        }

        private XName GetXName(string type)
        {
            return type.ToLowerInvariant() switch
            {
                // system
                "boolean" => namespaces["system"] + "Boolean",
                "bool" => namespaces["system"] + "Boolean",
                "byte" => namespaces["system"] + "Byte",
                "char" => namespaces["system"] + "Char",
                "datetime" => namespaces["system"] + "DateTime",
                "decimal" => namespaces["system"] + "Decimal",
                "double" => namespaces["system"] + "Double",
                "int16" => namespaces["system"] + "Int16",
                "int" => namespaces["system"] + "Int32",
                "int32" => namespaces["system"] + "Int32",
                "int64" => namespaces["system"] + "Int64",
                "object" => namespaces["system"] + "Object",
                "sbyte" => namespaces["system"] + "SByte",
                "single" => namespaces["system"] + "Single",
                "string" => namespaces["system"] + "String",
                "timespan" => namespaces["system"] + "TimeSpan",
                "uint16" => namespaces["system"] + "UInt16",
                "uint" => namespaces["system"] + "UInt32",
                "uint32" => namespaces["system"] + "UInt32",
                "uint64" => namespaces["system"] + "UInt64",
                "uri" => namespaces["system"] + "Uri",
                // e. t. c.
                _ => namespaces["xmlns"] + type
            };
        }

    }
}
