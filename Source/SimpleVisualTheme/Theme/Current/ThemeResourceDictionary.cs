using SimpleVisualTheme.Theme.Data;
using SimpleVisualTheme.Theme.Data.Internal;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SimpleVisualTheme.Theme.Current
{
    internal class ThemeResourceDictionary : ResourceDictionary
    {
        internal static ThemeResourceDictionary Instance { get; } = new ThemeResourceDictionary();
        
        private ThemeResourceDictionary() {
            Application.Current.Resources.MergedDictionaries.Add(this);
        }

        internal void Reset()
        {

            var themeData = ThemeDataGroup.Instance.GetData("Current");
            if (themeData is null)
            {
                return;
            }

            var keys = themeData.PropertyKeys();
            Parallel.ForEach(keys, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, key =>
            {
                if (themeData.GetProperty(key) is IThemeDataProperty property)
                {
                    if (property.XamlKey is null)
                    {
                        return;
                    }

                    var findType = FindType(property.Type);
                    if (findType is null)
                    {
                        return;
                    }

                    object? convertedValue = ConvertThemeDataValue(property.Value, findType);
                    if (convertedValue is null)
                    {
                        return;
                    }

                    Application.Current.Dispatcher.Invoke(() => {

                        if (Contains(property.XamlKey) is true && this[property.XamlKey] == convertedValue)
                        {
                            return;
                        }

                        this[property.XamlKey] = convertedValue;
                    });
                }
            });
        }

        internal void SetThemeProperty(string propertyName, string value)
        {
            var themeData = ThemeDataGroup.Instance.GetData("Current");
            if (themeData is null)
            {
                return;
            }

            if (themeData.GetProperty(propertyName) is not IThemeDataProperty property)
            {
                return;
            }

            if (property.XamlKey is null)
            {
                return;
            }

            Type? findType = FindType(property.Type);
            if (findType is null)
            {
                return;
            }

            object? convertedValue = ConvertThemeDataValue(value, findType);
            if (convertedValue is null)
            {
                return;
            }

            Application.Current.Dispatcher.Invoke(() => {

                if (Contains(property.XamlKey) is true && this[property.XamlKey] == convertedValue)
                {
                    return;
                }
                this[property.XamlKey] = convertedValue;
            });
        }

        internal T? GetThemeProperty<T>(string propertyName)
        {
            var themeData = ThemeDataGroup.Instance.GetData("Current");
            if (themeData is null)
            {
                return default;
            }

            if (themeData.GetProperty(propertyName) is not IThemeDataProperty property)
            {
                return default;
            }

            if (property.XamlKey is null)
            {
                return default;
            }

            if (IsValidType(FindType(property.Type), typeof(T)) is false)
            {
                return default;
            }

            if (Contains(property.XamlKey) is false)
            {
                return default;
            }

            object? resourceValue = this[property.XamlKey];

            if (resourceValue is T typedValue)
            {
                return typedValue;
            }
            else
            {
                return default;
            }
        }

        private readonly ConcurrentDictionary<string, Type> _typeDic = new()
        {
            ["boolean"] = typeof(bool),
            ["bool"] = typeof(bool),
            ["byte"] = typeof(byte),
            ["char"] = typeof(char),
            ["datetime"] = typeof(DateTime),
            ["decimal"] = typeof(decimal),
            ["double"] = typeof(double),
            ["int16"] = typeof(short),
            ["int"] = typeof(int),
            ["int32"] = typeof(int),
            ["int64"] = typeof(long),
            ["object"] = typeof(object),
            ["sbyte"] = typeof(sbyte),
            ["single"] = typeof(float),
            ["timespan"] = typeof(TimeSpan),
            ["uint16"] = typeof(ushort),
            ["uint"] = typeof(uint),
            ["uint32"] = typeof(uint),
            ["uint64"] = typeof(ulong),
            ["uri"] = typeof(Uri),
            ["string"] = typeof(string),
            ["solidcolorbrush"] = typeof(SolidColorBrush),
            ["brush"] = typeof(Brush),
            ["thickness"] = typeof(Thickness),
            ["cornerradius"] = typeof(CornerRadius),
            ["fontweight"] = typeof(FontWeight),
            ["textdecorationcollection"] = typeof(TextDecorationCollection),
            ["textalignment"] = typeof(TextAlignment),
        };

        private bool IsValidType(Type? targetType, Type compareType) =>
            targetType is null || targetType != compareType ? false : true;

        private Type? FindType(string typeName)
        {
            var FindTypeCaching = (string formet, string tpyename, out Type? type) =>
            {

                type = null;

                Type? getType = Type.GetType(String.Format(formet, typeName) , false, true);

                if (getType is null)
                {
                    return false;
                }

                type = getType;

                _typeDic.TryAdd(typeName.ToLowerInvariant(), type); //caching

                return true;

            };

            if (_typeDic.ContainsKey(typeName.ToLowerInvariant()) is true)
            {
                return _typeDic[typeName.ToLowerInvariant()];
            }

            if(FindTypeCaching("System.{}", typeName, out Type? systemType))
            {
                return systemType;
            }

            if (FindTypeCaching("System.Windows.{}", typeName, out Type? windowsType))
            {
                return windowsType;
            }

            if (FindTypeCaching("System.Windows.Media.{}", typeName, out Type? windowsMediaType))
            {
                return windowsMediaType;
            }

            if (FindTypeCaching("{}", typeName, out Type? nospaceType))
            {
                return nospaceType;
            }

            return null; //  not found type
        }

        private object? ConvertThemeDataValue(string value, Type type)
        {
            Dictionary<Type, Func<object?>> formetDic = new() {
                { typeof(SolidColorBrush), ()=>(SolidColorBrush?)new BrushConverter().ConvertFromString(value) },
                { typeof(Thickness), ()=>(Thickness?)new ThicknessConverter().ConvertFromString(value) },
                { typeof(CornerRadius), ()=>(CornerRadius?)new CornerRadiusConverter().ConvertFromString(value) },
                { typeof(FontWeight), ()=>(FontWeight?)new FontWeightConverter().ConvertFromString(value) },
                { typeof(TextDecorationCollection), ()=>TextDecorationCollectionConverter.ConvertFromString(value) },
                { typeof(TextAlignment), ()=>Enum.Parse(typeof(TextAlignment), value, true) }, // true for ignoreCase
            };

            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            Type actualType = Nullable.GetUnderlyingType(type) ?? type;
            TypeConverter? converter = TypeDescriptor.GetConverter(actualType);

            if (converter != null && converter.CanConvertFrom(typeof(string)))
            {
                object? result = converter.ConvertFromString(value);
                if (result is not null)
                {
                    return result;
                }
            }

            if (formetDic.ContainsKey(actualType) is true)
            {
                return formetDic[actualType];
            }

            return Convert.ChangeType(value, actualType);
        }

    }
}
